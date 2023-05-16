using DesafioRickAndMorty.Application.Service.DTOs.Response;

namespace DesafioRickAndMorty.Application.Service.Interface
{
    public interface IRickAndMortyApiService
    {
        Task<RootRickAndMortyResponseDto?> FindCharactersRequest(string baseUrl);
    }
}