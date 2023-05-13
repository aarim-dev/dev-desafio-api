using AC.Project.Domain.Entities.Enums;
using AC.Project.Resources.RickMorty.Entities;

namespace AC.Project.Domain.Gateways
{
    public interface RickMortyService
    {
        public Task<List<Character>> findCharacters(Status status = Status.unknown, string species = "alien");
    }
}
