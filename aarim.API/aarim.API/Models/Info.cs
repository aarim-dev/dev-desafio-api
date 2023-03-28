using Newtonsoft.Json;

namespace aarim.API.Models
{
    public sealed class Info
    {
        public int Count { get; set; }

        public int Pages { get; set; } 
        public string Next { get; set; }

        [JsonProperty("prev")]
        public string Previous { get; set; }
    }
}
