using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EldenRingWiki.Models;
using System.Net.Http;
using System.Text.Json;

namespace EldenRingWiki.Services
{
    public class BossService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://eldenring.fanapis.com/api/bosses?limit=500";
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public BossService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Boss>?> GetAllBosses()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentType?.MediaType == "application/json")
                    {
                        using var responseBody = await response.Content.ReadAsStreamAsync();

                        var bossResponse = await JsonSerializer.DeserializeAsync<BossResponse>(responseBody, _jsonOptions);

                        return bossResponse?.Data;
                    }
                    else
                    {
                        throw new Exception("Unexpected content type received from the server.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching locations: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error deserializing location data: {ex.Message}");
            }

            return null;
        }
    }
}
