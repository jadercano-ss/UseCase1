using System.Text.Json.Serialization;

namespace UserCase1.Models
{
    public record Name(
        [property: JsonPropertyName("common")] string Common,
        [property: JsonPropertyName("official")] string Official
    );
}
