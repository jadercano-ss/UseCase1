using System.Text.Json.Serialization;

namespace UserCase1.Models
{
    public record Country(
        [property: JsonPropertyName("name")] Name Name,
        [property: JsonPropertyName("population")] int Population

    );

}
