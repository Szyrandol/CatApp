using System.Text.Json;

namespace CatApp.Infrastructure.Persistence;

public class TextFileFactStorage : IFactStorage
{
    private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "AppData", "stored_facts.txt");
    private static readonly JsonSerializerOptions s_Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };
    public TextFileFactStorage() { }
    public async Task<CatFact?> Store(string stringFact)
    {
        var facts = await GetAll();
        var fact = JsonSerializer.Deserialize<CatFact>(stringFact, s_Options)!;
        facts.Add(fact);

        await StoreAll(facts);

        return fact;
    }

    public async Task<List<CatFact>> GetAll()
    {
        if (!File.Exists(filePath))
        {
           var directory = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directory!);
            return [];
        }

        var jsonString = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<CatFact>>(jsonString, s_Options) ?? [];
    }
    public async Task<bool> StoreAll(List<CatFact> facts)
    {
        var jsonText = JsonSerializer.Serialize(facts, s_Options);
        try
        {
            await File.WriteAllTextAsync(filePath, jsonText);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
