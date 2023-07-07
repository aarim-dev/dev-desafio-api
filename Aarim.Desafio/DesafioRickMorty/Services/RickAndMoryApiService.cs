using System;
using System.Collections.Generic;
using Aarim.Desafio.RickMorty.Helpers;
using Aarim.Desafio.RickMorty.Models;
using Aarim.Desafio.RickMorty.Services.Interfaces;

namespace Aarim.Desafio.RickMorty.Services
{
    public class RickAndMoryApiService : IRickAndMoryApiService
    {

        private readonly HttpClientHelper<RickAndMortyApiResponse> _Api;
        private readonly FilterCharacters _defaultFilter = new(page: 1);

        public RickAndMoryApiService(IConfiguration configuration)
        {
            string baseUrl = configuration["api:baseUrl"] ?? throw new Exception("BaseUrl api not found in appsettings.json");
            _Api = new(baseUrl);

        }

        public async Task<RickAndMortyApiResponse> GetPaginatedAsync(int page) =>
            await _Api.Get(new FilterCharacters(page).ToQueryString());
        
        public async Task<List<Character>> GetAllCharactersAsync(FilterCharacters? apiFilter)
        {
            List<Character> response = new();

            var apiResponse = await _Api.Get((apiFilter ?? _defaultFilter).ToQueryString());
            while(apiResponse.Results.Count > 0)
            {
                response.AddRange(apiResponse.Results);
                if (apiResponse.Info.Next.HasValue())
                    apiResponse = await _Api.Get(apiResponse.Info.Next ?? throw new Exception("Unexpected url to next page from api."));
                else break;
            }

            return response;
        }

        public async Task<List<Character>> GetChallengeAsync()
        {
            List<Character> response = await GetAllCharactersAsync(apiFilter: new()
            {
                Status = EStatus.Unknown,
                Species = "Alien",
            });

            return response
                .Where(c=> c.Episode?.Count > 1)
                .ToList();
        }

    }
}

