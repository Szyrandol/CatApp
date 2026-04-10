using CatApp.Application.Abstractions;
namespace CatApp.Infrastructure.Services.FactService;

public class FactClient : IFactClient
{
    private readonly HttpClient _httpClient;
    public FactClient(HttpClient httpClient)
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
