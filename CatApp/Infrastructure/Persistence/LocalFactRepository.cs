using CatApp.Domain.Repositories;
using System.Text.Json;

namespace CatApp.Infrastructure.Persistence
{
    public class LocalFactRepository : IFactRepository
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "AppData", "stored_facts.txt");
        public async Task CreateAsync(string stringFact)
        {
            var facts = await GetAllAsync();
            var fact = JsonSerializer.Deserialize<CatFact>(stringFact);
            facts.Add(fact);
            await SaveAllAsync(facts);
        }

        public async Task<List<CatFact>> GetAllAsync()
        {
            if (!File.Exists(filePath))
                return new List<CatFact>();

            var jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<CatFact>>(jsonString) ?? new List<CatFact>();
        }
        public async Task SaveAllAsync(List<CatFact> facts)
        {

            var json = JsonSerializer.Serialize(facts);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
