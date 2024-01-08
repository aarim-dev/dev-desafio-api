using System.Text.Json;
using dev_desafio_api.Dtos.ExternalServices;
namespace dev_desafio_api.ExternalServices
{
    public class RickAndMortyApiClient
    {
        private IHttpClientFactory _clientFactory;
        private JsonSerializerOptions _jsonSerializerOptions;

        public RickAndMortyApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<CharacterRespose>> GetAllCharactersAvailable()
        {
            using var httpClient = _clientFactory.CreateClient("RickAndMortyPublicApi");
            
            List<CharacterRespose> result = new();
            int page = 1;
            while(true)
            {
                var requestResult = await httpClient.GetAsync($"character?page={page}");
                var content = await requestResult.Content.ReadAsStringAsync();

                try
                {
                    CharactersResponse charactersToAdd = JsonSerializer.Deserialize<CharactersResponse>(content, _jsonSerializerOptions)!;
                    result.AddRange(charactersToAdd.Results);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                page++;
            }

            return result;
        }

        private async Task<List<CharacterRespose>> GetAllCharactersWithFilter(string status, string species)
        {
            using var httpClient = _clientFactory.CreateClient("RickAndMortyPublicApi");
            
            var requestResult = await httpClient.GetAsync($"character?status={status}&species={species}");
            CharactersResponse response = new();
            if(requestResult.IsSuccessStatusCode)
            {
                var content = await requestResult.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<CharactersResponse>(content, _jsonSerializerOptions)!;
            }

            return response.Results;
        }

        public async Task<List<CharacterRespose>> GetAllCharactersAvailableWithChallengeFilter()
        {
            List<CharacterRespose> result = await GetAllCharactersWithFilter("Unknown", "Alien");
            return result.
                Where(character =>
                    character.Episode.Count > 1).
                ToList();
        }
    }
}
