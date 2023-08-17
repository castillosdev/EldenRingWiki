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

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Location>?> GetAllLocations()
        {
            var response = await _httpClient.GetAsync("https://eldenring.fanapis.com/api/locations");

            if (response.IsSuccessStatusCode)
            {
                using var responseBody = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Location>>(responseBody);
            }

            return null;
        }
    }
}
