using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace aarim.API.Models
{
    public sealed class CharacterRoot
    {
        public Info Info { get; set; }
        public List<Character> Results { get; set; }
    }

    public sealed class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("origin")]
        public Location Origin { get; set; }

        [JsonProperty("episode")]
        public List<string> Episodes { get; set; }
    }
}
