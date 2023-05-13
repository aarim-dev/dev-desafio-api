using AC.Project.Domain.Entities.Enums;
using AC.Project.Domain.Gateways;
using AC.Project.Resources.RickMorty.Entities;
using AC.Project.Resources.RickMorty.Payloads;

namespace AC.Project.Resources.RickMorty
{
    public sealed class RickMortyImpl : RickMortyService
    {  
     
        private readonly RickMortyClient rickMortyClient;
         

        public static readonly Lazy<RickMortyImpl> rickMortyImpl = new Lazy<RickMortyImpl>(() => new RickMortyImpl());
        
        public static RickMortyImpl Instance { get { return rickMortyImpl.Value; } }

        public RickMortyImpl()
        {
            rickMortyClient = RickMortyClient.Instance;
        }

        public RickMortyImpl(RickMortyClient rickMortyClient)
        {
            this.rickMortyClient = rickMortyClient ?? RickMortyClient.Instance;
        }

        public async Task<List<Character>> findCharacters(Status status = Status.unknown, string species = "alien")
        {

           FindCharacterResponseV1 response = await rickMortyClient.findCharactersByStatusAndSpecies(Enum.GetName(typeof(Status), status), species);

           return response.results;

        }
    }
}
