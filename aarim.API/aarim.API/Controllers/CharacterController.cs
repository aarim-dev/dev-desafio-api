using aarim.API.ExternalAPI;
using aarim.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace aarim.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string status, string species, int minimoEpisodios)
        {
            var characters = await GetCharacterAsync(status, species, minimoEpisodios);

            return Ok(characters);
        }

        private async Task<CharacterRoot> GetCharacterAsync(string status = default, string species = null, int minimoEpisodios = 1, int page = 1)
        {
            string filter = $"https://rickandmortyapi.com/api/character/?page={page}";

            if (status != default)
                filter += $"&status={status}";

            if (species != null)
                filter += $"&species={species}";

            var json = await (await new ApiRequester().RequestAPIAsync(filter)).Content.ReadAsStringAsync();

            var characters = JsonConvert.DeserializeObject<CharacterRoot>(json,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            if (characters == null)
                return new CharacterRoot();

            characters.Results = characters?.Results?.Where(x => x.Episodes.Count() >= minimoEpisodios).ToList();
            return characters;
        }
    }
}
