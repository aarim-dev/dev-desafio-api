using AarimChallenge.API.Data.Config;
using AarimChallenge.API.Data.Filters;
using AarimChallenge.API.Data.Responses;
using AarimChallenge.API.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace AarimChallenge.API.Services.Concretes
{
    public class CharactersService : ICharactersService
    {
        private readonly HttpClient _rickAndMortyHttpClient;
        private readonly IConfiguration _config;
        private readonly RickAndMortyApiConfig _rickAndMortyApiConfig;

        public CharactersService(IConfiguration config, HttpClient rickAndMortyHttpClient)
        {
            _config = config;
            _rickAndMortyHttpClient = rickAndMortyHttpClient;
            _rickAndMortyApiConfig = new RickAndMortyApiConfig(_config);
        }

        public async Task<IEnumerable<string?>> GetNamesShownInMoreThanOneOrMoreEpisodesByStatusAndSpeciesAsync(CharacterFilter filters)
        {
            CharacterResponse? deserialized = null;

            var endpoint = GetEndpoint(filters);

            var response = await _rickAndMortyHttpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"There was a problem with the endpoint {endpoint}.");

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
                throw new Exception($"Response body from endpoint is empty.");

            try
            {
                deserialized = JsonSerializer.Deserialize<CharacterResponse>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem deserializing the response.", ex);
            }

            var result = deserialized?.Results?.Where(x => x.Episodes != null && x.Episodes.Length > filters.EpisodesShownGreaterThan);

            return result?.Select(x => x.Name) ?? Array.Empty<string>();
        }

        private IDictionary<string, string?> GetQueryDict(CharacterFilter filters) 
        {
            return new Dictionary<string, string?>()
            {
                ["status"] = filters.Status,
                ["species"] = filters.Species,
            };
        }

        private string GetEndpoint(CharacterFilter filters)
        {
            return QueryHelpers.AddQueryString(_rickAndMortyApiConfig.CharactersEnpoint!, GetQueryDict(filters));
        }
    }
}
