using CatApp.Domain.Repositories;
using System.Text.Json;

namespace CatApp.Infrastructure.Persistence;

public class TextFileFactStorage : IFactStorage
{
    private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "AppData", "stored_facts.txt");
    private static readonly JsonSerializerOptions s_writeOptions = new()
    {
        WriteIndented = true,
    };
    public async Task<bool> SaveFactAsync(string stringFact)
    {
        var facts = await GetAllAsync();
        var fact = JsonSerializer.Deserialize<CatFact>(stringFact);
        facts.Add(fact);

        return await SaveAllAsync(facts);
    }

    public async Task<List<CatFact>> GetAllAsync()
    {
        if (!File.Exists(filePath))
            return [];

        var jsonString = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<CatFact>>(jsonString) ?? [];
    }
    public async Task<bool> SaveAllAsync(List<CatFact> facts)
    {
        var json = JsonSerializer.Serialize(facts, s_writeOptions);
        try
        {
            await File.WriteAllTextAsync(filePath, json);
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
