using DesafioRickAndMorty.Application.Service.DTOs.Response;

namespace DesafioRickAndMorty.Application.UseCases.RickAndMortyCharacters.Interface
{
    public interface IRickAndMortyCharactersUseCase
    {
        Task<List<ResultResponseDto>> FindCharactersByFilters(string status, string specie, int minimumEpisode);
    }
}