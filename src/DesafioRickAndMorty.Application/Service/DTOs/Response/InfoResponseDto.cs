namespace DesafioRickAndMorty.Application.Service.DTOs.Response
{
    public class InfoResponseDto
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string? Next { get; set; }
        public string? Prev { get; set; }
    }
}