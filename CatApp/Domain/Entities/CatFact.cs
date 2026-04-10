using System.Text.Json.Serialization;
namespace CatApp.Domain.Entities;

public class CatFact
{
    public string Fact {  get; set; }
    public int Length { get; set; }

    [JsonConstructor]
    public CatFact(string fact, int length)
    {
        Fact = fact;
        Length = length;
    }
}
