using AC.Project.Domain.Entities.Enums;
using Newtonsoft.Json;

namespace AC.Project.Resources.RickMorty.Entities
{
    public class Character
    {
        public int id { get; set; }

        public string name { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        public string species { get; set; }

        public string type { get; set; }

        public string gender { get; set; }

        public object origin { get; set; }

        public object location { get; set; }

        public string image { get; set; }

        public IEnumerable<string> episode { get; set; }

        public string url { get; set; }

        public string created { get; set; }

        public Character() { }

        public Character(
            int id,
            string name,
            string status,
            string species,
            string type,
            string gender,
            object origin,
            object location, 
            string image, 
            IEnumerable<string> episode,
            string url,
            string created
           )
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.species = species;
            this.type = type;
            this.gender = gender;
            this.origin = origin;
            this.location = location;
            this.image = image;
            this.episode = episode;
            this.url = url;
            this.created = created;
        }
    }
}
