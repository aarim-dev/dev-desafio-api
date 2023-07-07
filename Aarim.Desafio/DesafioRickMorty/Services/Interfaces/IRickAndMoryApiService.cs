using System;
using Aarim.Desafio.RickMorty.Models;

namespace Aarim.Desafio.RickMorty.Services.Interfaces
{
	public interface IRickAndMoryApiService
	{
        Task<RickAndMortyApiResponse> GetPaginatedAsync(int page = 1);
        Task<List<Character>> GetAllCharactersAsync(FilterCharacters? filter = null);
        Task<List<Character>> GetChallengeAsync();

    }
}

