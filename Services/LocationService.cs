using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EldenRingWiki.Models;
using System.Net.Http;
using System.Text.Json;

namespace EldenRingWiki.Services
{
    public class LocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://eldenring.fanapis.com/api/locations"; // Ideally, fetch from configuration.
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Location>?> GetAlllocations()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentType?.MediaType == "application/json")
                    {
                        using var responseBody = await response.Content.ReadAsStreamAsync();

                        // Deserialize using the specified JSON options
                        var locationResponse = await JsonSerializer.DeserializeAsync<LocationResponse>(responseBody, _jsonOptions);

                        // Return the Data property which contains the locations
                        return locationResponse?.Data;
                    }
                    else
                    {
                        throw new Exception("Unexpected content type received from the server.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the network-related exception here
                throw new Exception($"Error fetching locations: {ex.Message}");
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization exception
                throw new Exception($"Error deserializing location data: {ex.Message}");
            }

            return null;
        }
    }
}
