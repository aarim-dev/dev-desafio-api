using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RickAndMortyApi.Wrapper.Interfaces;
using RickAndMortyApi.Wrapper.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RickAndMorty.Controllers
{
    [ApiController]
    [Route("api/rick-and-morty/characters")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno.")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly IRickAndMortyCharacters _rickAndMortyCharacters;

        public CharacterController(
            ILogger<CharacterController> logger,
            IRickAndMortyCharacters rickAndMortyCharacters)
        {
            _logger = logger;
            _rickAndMortyCharacters = rickAndMortyCharacters;
        }

        [HttpGet("filtered")]
        [SwaggerOperation("Personagens filtrados", Description = "Lista os personagens por status e species e quantidade mínima de episódios.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Requisição executada com sucesso.", typeof(IList<RickAndMortyCharacter>))]
        public async Task<IActionResult> ListByStatusAndSpeciesAndMinimumEpisodesAsync(string status, string species, int minimumEpisodes)
        {
            try
            {
                var result = await _rickAndMortyCharacters.ListByStatusAndSpeciesAndMinimumEpisodesAsync(status, species, minimumEpisodes);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
