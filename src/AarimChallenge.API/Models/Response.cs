using System.Text.Json.Serialization;

namespace AarimChallenge.API.Models
{
    public class Response
    {
        [JsonPropertyName("results")]
        public IEnumerable<Character>? Results { get; set; }
    }
}
