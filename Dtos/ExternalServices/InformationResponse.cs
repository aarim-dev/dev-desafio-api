namespace dev_desafio_api.Dtos.ExternalServices
{
    public class InformationResponse
    {
        public int Count { get; set; }
        
        public int Pages { get; set; }

        public string Next { get; set; } = string.Empty;

        public string Prev { get; set; } = string.Empty;
    }
}
