using System.Text.Json;

namespace CatApp.Infrastructure.Services.FactService
{
    public class FactService : IFactService
    {
        HttpClient httpClient;
        public FactService()
        {
            httpClient = new HttpClient();
        }
        public async Task<string> Get()
        {
            var url = "https://catfact.ninja/fact";
            var request = await httpClient.GetAsync(url);
            if (request.IsSuccessStatusCode)
            {
                var json = await request.Content.ReadAsStringAsync();
                return json;
            }
            else
            {
                throw new Exception("request is unsuccessfull");
            }
        }
    }
}
