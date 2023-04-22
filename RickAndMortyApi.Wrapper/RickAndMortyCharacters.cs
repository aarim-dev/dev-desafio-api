using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RickAndMorty.CrossCutting.Settings;
using RickAndMortyApi.Wrapper.Interfaces;
using RickAndMortyApi.Wrapper.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMortyApi.Wrapper
{
    public class RickAndMortyCharacters : IRickAndMortyCharacters
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private List<RickAndMortyCharacter> _filteredCharacters;

        public RickAndMortyCharacters(
            AppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient(_appSettings.RickAndMortyApiSettings.Id);

        public async Task<IList<RickAndMortyCharacter>> ListByStatusAndSpeciesAndMinimumEpisodesAsync(string status, string species, int minimumEpisodes)
        {
            var queryString = new Dictionary<string, string>();
            
            if (!string.IsNullOrWhiteSpace(status))
                queryString.Add("status", status);

            if (!string.IsNullOrWhiteSpace(species))
                queryString.Add("species", species);
            
            var requestUri = QueryHelpers.AddQueryString("character", queryString);

            _filteredCharacters = new List<RickAndMortyCharacter>();
            await GetFilteredCharactersAsync(requestUri);

            return _filteredCharacters.Where(x => x.Episode.Count >= minimumEpisodes).ToList();
        }

        private async Task GetFilteredCharactersAsync(string requestUri)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            
            using var response = await GetClient().SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var convertedContent = JsonConvert.DeserializeObject<RickAndMortyResponse<RickAndMortyCharacter>>(content);

            if (convertedContent.Results != null && convertedContent.Results.Any())
                _filteredCharacters.AddRange(convertedContent.Results);

            if (!string.IsNullOrWhiteSpace(convertedContent.Info.Next))
                await GetFilteredCharactersAsync(convertedContent.Info.Next);
        }
    }
}
