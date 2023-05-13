using AC.Project.Application.Web.Payloads;
using AC.Project.Domain.Services;
using AC.Project.Resources.RickMorty.Entities;
using AC.Project.Resources.RickMorty.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AC.Project.Application.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        CharactersService charactersService = CharactersService.Instance;

        private readonly ILogger<CharactersController> _logger;

        public CharactersController(ILogger<CharactersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<GetCharacterResponseV1>> Get()
        {
            try
            {
                List<Character> characters = await charactersService.getAllAlienAndUnknown();
                return new GetCharacterResponseV1("OK", characters);

            }
            catch(RickMortyClientException ex)
            {
                Response.StatusCode = (int)ex.statusCode;
                return new GetCharacterResponseV1(ex.Message);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new GetCharacterResponseV1(ex.Message);
            }
        }
    }
}