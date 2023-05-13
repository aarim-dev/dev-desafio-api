using AC.Project.Resources.RickMorty.Exceptions;
using AC.Project.Resources.RickMorty.Payloads;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;


namespace AC.Project.Resources.RickMorty
{
    public sealed class RickMortyClient
    {
        public static HttpClient client { get; set; }

        public static readonly Lazy<RickMortyClient> rickMortyClient = new Lazy<RickMortyClient>(() => new RickMortyClient());

        public static RickMortyClient Instance { get { return rickMortyClient.Value; } }

        public RickMortyClient()
        {
            string baseUrl = Environment.GetEnvironmentVariable("RICK_MORTY_BASE_PATH");
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<FindCharacterResponseV1> findCharactersByStatusAndSpecies(string status, string species)
        {
            using (HttpResponseMessage response = await client.GetAsync($"character/?species={species}&status={status}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<FindCharacterResponseV1>(responseString)!;
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new RickMortyClientException("Character with the provided filters was not found", HttpStatusCode.NotFound);
                }

                throw new RickMortyClientException("Generic Client Exception");


            }
        }
    }
}
