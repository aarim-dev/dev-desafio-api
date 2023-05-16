using DesafioRickAndMorty.Application.Service.DTOs.Response;
using DesafioRickAndMorty.Application.Service.Interface;
using DesafioRickAndMorty.Application.UseCases.RickAndMortyCharacters.Interface;
using Microsoft.Extensions.Configuration;

namespace DesafioRickAndMorty.Application.UseCases
{
    public class RickAndMortyCharactersUseCase : IRickAndMortyCharactersUseCase
    {
        private readonly IRickAndMortyApiService _rickAndMortyApiService;
        private readonly IConfiguration _configuration;
        public List<ResultResponseDto> Results { get; set; }

        public RickAndMortyCharactersUseCase(IRickAndMortyApiService rickAndMortyApiService, IConfiguration configuration)
        {
            _rickAndMortyApiService = rickAndMortyApiService;
            _configuration = configuration;
            Results = new List<ResultResponseDto>();
        }

        public async Task<List<ResultResponseDto>> FindCharactersByFilters(string status, string specie, int minimumEpisode)
        {
            var url = _configuration.GetSection("RickAndMortyApi:BaseUrl").Value;

            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Miss BaseUrl");

            url = url += $"/character?status={status}&species={specie}";

            var characters = await FindRecursive(url);

            return characters.Where(x => x.Episode.Count >= minimumEpisode).ToList();
        }

        private async Task<List<ResultResponseDto>> FindRecursive(string url)
        {
            var requestResponse = await _rickAndMortyApiService.FindCharactersRequest(url);

            if (requestResponse != null && requestResponse.Results.Any())
            {
                Results.AddRange(requestResponse.Results);

                if (requestResponse?.Info?.Next != null)
                    await FindRecursive(requestResponse?.Info.Next);
            }

            return Results;
        }
    }
}