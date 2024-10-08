using DevDesafioMagvaBusZap.Models;
using DevDesafioMagvaBusZap.Models.Results;
using DevDesafioMagvaBusZap.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DevDesafioMagvaBusZap.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class RickAndMortyApiController : ControllerBase
    {
        private readonly IApiService _apiService;
        public RickAndMortyApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        #region Swagger
        /// <summary>
        /// Retrieves character data by requested parameters.
        /// </summary>
        /// <returns>
        /// A list of characters. 
        /// In case of an error, returns an <see cref="Error"/> object.
        /// </returns>
        /// <response code="200">Returns a list of characters</response>
        /// <response code="404">If no character is found</response>
        /// <response code="500">If there is an internal server error</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResponse<List<Character>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Paginate parameters)
        {
            var result = await _apiService.GetDataByRequestedParameters();

            if (result.IsFailure)
            {
                return BadRequest(result.Error.Description);
            }

            var paginatedResponse = PaginateResult(result.Value, parameters);

            if (!paginatedResponse.Data.Any())
            {
                return NotFound(new Error("RickAndMortyApiController.GetAsync", "Nenhum personagem encontrado."));
            }

            return Ok(paginatedResponse);
        }

        private PaginatedResponse<T> PaginateResult<T>(List<T> characters, Paginate paginationParameters)
        {
            int totalRecords = characters.Count;

            int totalPages = (int)Math.Ceiling(totalRecords / (double)paginationParameters.Count);

            int skip = (paginationParameters.Page - 1) * paginationParameters.Count;
            var paginatedData = characters
                .Skip(skip)
                .Take(paginationParameters.Count)
                .ToList();

            return new PaginatedResponse<T>
            {
                Data = paginatedData,
                TotalRecords = totalRecords,
                CurrentPage = paginationParameters.Page,
                TotalPages = totalPages,
                HasNextPage = paginationParameters.Page < totalPages,
                HasPreviousPage = paginationParameters.Page > 1
            };
        }
    }
}
