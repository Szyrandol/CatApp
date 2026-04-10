namespace CatApp.Application.Abstractions
{
    public interface IFactClient
    {
        public Task<string> Get();
    }
}
