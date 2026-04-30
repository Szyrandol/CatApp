namespace CatApp.Application.Abstractions;

public interface IFactService
{
    Task<CatFact> GetAndStore();
    Task<List<CatFact>> GetAll();
    Task<string> GetAllAsString();
}
