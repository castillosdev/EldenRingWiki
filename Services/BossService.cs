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

        public BossService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Boss>?> GetAllBosses()
        {
            var response = await _httpClient.GetAsync("https://eldenring.fanapis.com/api/bosses");

            if (response.IsSuccessStatusCode)
            {
                using var responseBody = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<Boss>>(responseBody);
            }

            return null;
        }
    }
}
