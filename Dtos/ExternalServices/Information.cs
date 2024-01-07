namespace dev_desafio_api.Dtos.ExternalServices
{
    public class Information
    {
        int Count { get; set; }
        
        int Pages { get; set; }

        string Next { get; set; } = string.Empty;

        string Prev { get; set; } = string.Empty;
    }
}
