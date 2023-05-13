
using AC.Project.Resources.RickMorty.Entities;

namespace AC.Project.Domain.Services.Operations
{
    public interface CharactersServiceOperations
    {
        public Task<List<Character>> getAllAlienAndUnknown(int times);
    }
}
