using System.Text.Json.Serialization;

namespace AarimChallenge.API.Models
{
    public class Character
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("episode")]
        public string[]? Episodes { get; set; }
    }
}
