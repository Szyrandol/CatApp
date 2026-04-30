
namespace CatApp.Domain.Repositories;

public interface IFactStorage
{
    Task<CatFact?> Store(string fact);
    Task<List<CatFact>> GetAll();
    Task<bool> StoreAll(List<CatFact> facts);
    Task<string> GetAllAsString();
}
