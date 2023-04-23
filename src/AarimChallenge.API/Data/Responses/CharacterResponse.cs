using System.Text.Json.Serialization;
using AarimChallenge.API.Data.Dtos;

namespace AarimChallenge.API.Data.Responses
{
    public class CharacterResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<CharacterDto>? Results { get; set; }
    }
}
