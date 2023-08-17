using System.Collections.Generic;
using System.Threading.Tasks;
using EldenRingWiki.Models;
using System.Net.Http;
using System.Text.Json;

namespace EldenRingWiki.Services
{
    public class CreatureService
    {
        private readonly HttpClient _httpClient;

        public CreatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Creature>?> GetAllCreatures()
        {
            var response = await _httpClient.GetAsync("https://eldenring.fanapis.com/api/creatures");

            if (response.IsSuccessStatusCode)
            {
                using var responseBody = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Creature>>(responseBody);
            }

            return null;
        }
    }
}
