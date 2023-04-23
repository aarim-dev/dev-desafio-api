using System.Text.Json.Serialization;

namespace AarimChallenge.API.Data.Dtos
{
    public class CharacterDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("episode")]
        public string[]? Episodes { get; set; }
    }
}
