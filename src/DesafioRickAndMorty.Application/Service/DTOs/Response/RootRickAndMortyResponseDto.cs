namespace DesafioRickAndMorty.Application.Service.DTOs.Response
{
    public class RootRickAndMortyResponseDto
    {
        public RootRickAndMortyResponseDto()
        {
            Info = new InfoResponseDto();
            Results = new List<ResultResponseDto>();
        }

        public InfoResponseDto Info { get; set; }

        public List<ResultResponseDto> Results { get; set; }
    }
}