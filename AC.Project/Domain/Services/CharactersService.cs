using AC.Project.Application.Web.Payloads;
using AC.Project.Domain.Gateways;
using AC.Project.Domain.Services.Operations;
using AC.Project.Resources.RickMorty;
using AC.Project.Resources.RickMorty.Entities;

namespace AC.Project.Domain.Services
{
    public class CharactersService : CharactersServiceOperations
    {
        private readonly RickMortyImpl rickmortyService;

        public static readonly Lazy<CharactersService> charactersService = new Lazy<CharactersService>(() => new CharactersService());

        public static CharactersService Instance { get { return charactersService.Value; } }

        public CharactersService() 
        {
            rickmortyService = RickMortyImpl.Instance;
        }

        public async Task<List<Character>> getAllAlienAndUnknown(int times = 1)
        {
            List<Character> characters = await rickmortyService.findCharacters();
            return characters.FindAll(r => r.episode.Count() > times); 
        }
    }
}
