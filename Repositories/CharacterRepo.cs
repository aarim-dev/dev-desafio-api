using dev_desafio_api.DataAccess.MongoDb;
using dev_desafio_api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace dev_desafio_api.Repositories
{
    public class CharacterRepo
    {
        private IMongoQueryable<Character>  characterQueryableSet;

        public CharacterRepo(RickAndMortyDao rickAndMortyDao)
        {
            characterQueryableSet = rickAndMortyDao.GetCharacterCollection();
        }

        public List<Character> GetAll()
        {
            return characterQueryableSet.ToList();
        }

        public List<Character> GetAllWithFilterChallenge()
        {
            throw new NotImplementedException();
        }
    }
}
