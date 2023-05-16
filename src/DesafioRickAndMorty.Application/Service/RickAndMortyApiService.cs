using DesafioRickAndMorty.Application.Service.DTOs.Response;
using DesafioRickAndMorty.Application.Service.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DesafioRickAndMorty.Application.Service
{
    public class RickAndMortyApiService : IRickAndMortyApiService
    {
        public async Task<RootRickAndMortyResponseDto?> FindCharactersRequest(string baseUrl)
        {
            var client = new RestClient();

            var request = new RestRequest(baseUrl);

            var response = await client.ExecuteAsync(request);
            if (response != null)
            {
                if (response.IsSuccessful)
                    return JsonConvert.DeserializeObject<RootRickAndMortyResponseDto>(response.Content ?? string.Empty);
                else if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
                    return null;
            }

            throw new Exception($"Request Error {response?.ErrorMessage}");
        }
    }
}