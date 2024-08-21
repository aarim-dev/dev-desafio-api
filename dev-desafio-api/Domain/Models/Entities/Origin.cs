using System.Text.Json.Serialization;

namespace Domain.Models.Entities
{
    public class Origin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}