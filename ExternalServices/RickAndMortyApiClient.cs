using System.Text.Json;
using dev_desafio_api.Dtos.ExternalServices;
using dev_desafio_api.Models;

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

        public async Task<List<Character>> GetAllCharactersAvailable()
        {
            using var httpClient = _clientFactory.CreateClient("RickAndMortyPublicApi");
            
            List<Character> result = new();
            int page = 1;
            while(true)
            {
                var requestResult = await httpClient.GetAsync($"character?page={page}");
                var content = requestResult.Content.ReadAsStringAsync().Result;

                Console.Write(result);

                try
                {
                    CharactersResponse charactersToAdd = JsonSerializer.Deserialize<CharactersResponse>(content, _jsonSerializerOptions)!;
                    result.AddRange(charactersToAdd.Result);
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

        public async Task<List<Character>> GetAllCharactersAvailableWithChallengeFilter()
        {
            List<Character> result = await GetAllCharactersAvailable();
            return result.
                Where(character =>
                    character.Status == "Unknown" && character.Species == "Alien" && character.Episodes.Count > 0).
                ToList();
        }
    }
}
