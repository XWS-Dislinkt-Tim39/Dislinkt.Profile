using MongoDB.Driver;

namespace Dislinkt.Profile.Persistance.MongoDB.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Create();
    }
}
