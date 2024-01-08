using MongoDB.Driver;
using MongoDB.Bson;
using dev_desafio_api.Models;
using MongoDB.Driver.Linq;

namespace dev_desafio_api.DataAccess.MongoDb
{
    public class RickAndMortyDao
    {
        private MongoClientSettings _settings;
        public RickAndMortyDao()
        {
            const string connectionUri = "mongodb+srv://RickAndMortyClusterSample:P7aK7wdw.r8i6nv@cluster0.ijbvvcb.mongodb.net/?retryWrites=true&w=majority";
            _settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            _settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
        }

        private MongoClient GetClient()
        {
            var client = new MongoClient(_settings);
            
            // Send a ping to confirm a successful connection
            try {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return client;
        }

        //o uso correto deveria ser: o GetCharacterCollection é privado 
        //e repositório passa somente os filtros sem conhecer o banco de dados
        //que a data access layer usa, mas fiz assim por causa do tempo
        public IMongoQueryable<Character> GetCharacterCollection() =>
            GetClient().GetDatabase("RickyAndMortyDb").GetCollection<Character>("Character").AsQueryable();
    }
}
