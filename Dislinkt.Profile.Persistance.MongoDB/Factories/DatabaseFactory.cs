using MongoDB.Driver;

namespace Dislinkt.Profile.Persistance.MongoDB.Factories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public IMongoDatabase Create()
        {
            var mongoClient = new MongoClient("MongoSettings:ConnectionString");
            return mongoClient.GetDatabase("MongoSettings:DatabaseName"); 
        }
    }
}
