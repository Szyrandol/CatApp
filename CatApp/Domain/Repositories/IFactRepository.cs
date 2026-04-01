using CatApp.Domain.Entities;

namespace CatApp.Domain.Repositories;

public interface IFactRepository
{
    Task CreateAsync(@string fact);
    Task<List<@string>> GetAllAsync();
}
