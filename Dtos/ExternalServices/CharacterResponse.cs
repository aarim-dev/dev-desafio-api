
namespace dev_desafio_api.Dtos.ExternalServices
{
    public class CharacterRespose
    {
        public int Id { get; set;}

        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Species { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public LocationResponse? Origin { get; set; }

        public LocationResponse? Location { get; set; }

        public List<string> Episodes { get; set; } = new();

        public string Image { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public DateTime Created { get; set; }
    }
}