using Newtonsoft.Json;

namespace aarim.API.Models
{
    public sealed class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
