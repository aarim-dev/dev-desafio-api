using AarimChallenge.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace AarimChallenge.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly IDictionary<string, string?> _queryDict = new Dictionary<string, string?>()
        {
            ["status"] = "unknown",
            ["species"] = "alien",
        };

        public HomeController(IConfiguration config, HttpClient httpClient, ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
            _endpoint = QueryHelpers.AddQueryString(config["RickAndMortyAPI:CharactersEnpoint"], _queryDict);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetAsync(_endpoint);

            Response? deserialized = null;

            if (!response.IsSuccessStatusCode)
                return BadRequest($"There was a problem with the endpoint {_endpoint}.");

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(json))
                return BadRequest($"Response body from endpoint is empty.");

            try
            {
                deserialized = JsonSerializer.Deserialize<Response>(json);
            }
            catch (Exception ex)
            {
                var message = "There was a problem deserializing the response.";
                _logger.LogError(ex, message);
                return StatusCode(500, message);
            }

            var result = deserialized?.Results?.Where(x => x.Episodes != null && x.Episodes.Length > 1);

            return Ok(result?.Select(x => x.Name) ?? Array.Empty<string>());
        }
    }
}