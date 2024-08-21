using Domain.Models.Entities;
using System.Text.Json.Serialization;

namespace Domain.Models.Dto
{
    public class ResponseDto
    {
        [JsonPropertyName("info")]
        public InfoDto Info { get; set; }

        [JsonPropertyName("results")]
        public List<Character> Results { get; set; }
    }
}