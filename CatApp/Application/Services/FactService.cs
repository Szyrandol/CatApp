namespace CatApp.Application.Services;

public class FactService : IFactService
{
    private readonly IFactClient _factClient;
    private readonly IFactStorage _factStorage;
    public FactService(IFactClient factClient, IFactStorage factStorage)
    {
        _factClient = factClient;
        _factStorage = factStorage;
    }
    public async Task<CatFact> GetAndStore()
    {
        var stringFact = await _factClient.Get();
        var fact = await _factStorage.Store(stringFact)!;

        return fact;
    }
    public async Task<List<CatFact>> GetAll()
    {
        return await _factStorage.GetAll();
    }
}
