using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Persistance.MongoDB.Repositories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public InterestRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task AddAsync(Interest interest)
        {
            try
            {
                await _queryExecutor.CreateAsync<InterestEntity>(InterestEntity.ToInterestEntity(interest));
            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }
        }
    }
}
