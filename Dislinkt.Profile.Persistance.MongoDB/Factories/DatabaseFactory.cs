using MongoDB.Driver;

namespace Dislinkt.Profile.Persistance.MongoDB.Factories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public IMongoDatabase Create()
        {
           // var mongoClient = new MongoClient("mongodb+srv://aleksandramitro:SifrazaMongo99!@cluster0.qmuvt.mongodb.net/xml?retryWrites=true&w=majority");
           var mongoClient = new MongoClient("mongodb://mongodb:27017");
            return mongoClient.GetDatabase("ProfileDB"); 
        }
    }
}
