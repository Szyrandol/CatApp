using System.Text.Json;

namespace CatApp.Infrastructure.Services.FactService
{
    public class FactService : IFactService
    {
        private readonly HttpClient _httpClient;
        public FactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> Get()
        {
            var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
