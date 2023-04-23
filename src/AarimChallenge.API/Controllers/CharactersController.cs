using AarimChallenge.API.Data.Filters;
using AarimChallenge.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AarimChallenge.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly ICharactersService _charactersService;

        public CharactersController(ILogger<CharactersController> logger, ICharactersService charactersService)
        {
            _logger = logger;
            _charactersService = charactersService;
        }

        /// <summary>
        /// Gets a list of characters names shown in more than specified status, species and shown quantity episodes.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>List of characters names</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetNamesShownInMoreThanOneOrMoreEpisodesByStatusAndSpeciesAsync([FromQuery]CharacterFilter filters)
        {
            try
            {
                if (!filters.IsValid(out string message))
                    return BadRequest(message);

                var result = await _charactersService.GetNamesShownInMoreThanOneOrMoreEpisodesByStatusAndSpeciesAsync(filters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}