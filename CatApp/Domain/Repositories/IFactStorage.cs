using CatApp.Domain.Entities;

namespace CatApp.Domain.Repositories;

public interface IFactStorage
{
    Task<bool> SaveFactAsync(string fact);
    Task<List<CatFact>> GetAllAsync();
    Task<bool> SaveAllAsync(List<CatFact> facts);
}
