using DevDesafioMagvaBusZap.Models;
using DevDesafioMagvaBusZap.Models.Results;
using DevDesafioMagvaBusZap.Service.Interface;
using System.Text.Json;

namespace DevDesafioMagvaBusZap.Service
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Fixed challenge parameters
        /// Status = unknown
        /// Species = alien
        /// Apareceram em mais de 1 episódio
        /// </summary>
        private const string EndpointAndParams = "api/character?status=unknown&species=alien";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result<List<Character>>> GetDataByRequestedParameters()
        {
            try
            {
                var jsonResponse = await GetJsonResponse(EndpointAndParams);
                var characters = DeserializeCharacters(jsonResponse);

                if (characters.IsFailure || !characters.Value.Any())
                {
                    return Result.Failure<List<Character>>(new Error("ApiService.GetCharacterAsync", $"Nenhum dado encontrado"));
                }

                var characterAppearsInMoreThanOneEpisode = characters.Value.Where(character => character.Episode.Count > 1).ToList();
                return Result.Success(characterAppearsInMoreThanOneEpisode);
            }
            catch (HttpRequestException ex)
            {
                return Result.Failure<List<Character>>(new Error("ApiService.GetDataByRequestedParameters", ex.Message));
            }
        }

        private async Task<string> GetJsonResponse(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro status code: {response.StatusCode}, detalhes: {jsonResponse}");
            }
            return await response.Content.ReadAsStringAsync();
        }

        private Result<List<Character>> DeserializeCharacters(string jsonResponse)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };
                var resultModel = JsonSerializer.Deserialize<ApiResponse>(jsonResponse, options);

                return Result.Success(resultModel?.results ?? new List<Character>()) ;
            }
            catch (JsonException ex)
            {
                return Result.Failure<List<Character>>(new Error("ApiService.GetCharacterAsync", $"Erro ao desserializar JSON: {ex.Message}"));
            }
        }
    }
}
