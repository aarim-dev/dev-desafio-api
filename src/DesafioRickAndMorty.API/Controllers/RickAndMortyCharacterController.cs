using DesafioRickAndMorty.Application.UseCases.RickAndMortyCharacters.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioRickAndMorty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyCharacterController : ControllerBase
    {
        private readonly IRickAndMortyCharactersUseCase _rickAndMortyCharactersUseCase;
        private readonly ILogger<RickAndMortyCharacterController> _logger;

        public RickAndMortyCharacterController(IRickAndMortyCharactersUseCase rickAndMortyCharactersUseCase,
            ILogger<RickAndMortyCharacterController> logger)
        {
            _rickAndMortyCharactersUseCase = rickAndMortyCharactersUseCase;
            _logger = logger;
        }

        /// <summary>
        /// Obtém o conjunto de personagens que apareceram em episódios conforme filtro
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="species">specie</param>
        /// <param name="minimumAppearanceEpisodes">minimumAppearanceEpisodes</param>
        /// <response code="200">Operação realizada com sucesso</response>
        /// <response code="204">Operação não retornou registros</response>
        /// <response code="500">Ocorreu um problema de validação</response>
        [HttpGet("Find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ListByStatusAndSpeciesAndMinimumEpisodesAsync(string status, string species, int minimumAppearanceEpisodes)
        {
            try
            {
                var result = await _rickAndMortyCharactersUseCase.FindCharactersByFilters(status, species, minimumAppearanceEpisodes);

                if (!result.Any())
                    return NoContent();

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