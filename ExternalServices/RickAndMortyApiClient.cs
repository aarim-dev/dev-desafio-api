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

        public async Task<List<CharacterRespose>> GetAllCharactersAvailableWithChallengeFilter()
        {
            List<CharacterRespose> result = await GetAllCharactersAvailable();
            return result.
                Where(character =>
                    character.Status == "unknown" && character.Species == "Alien" && character.Episode.Count > 0).
                ToList();
        }
    }
}
