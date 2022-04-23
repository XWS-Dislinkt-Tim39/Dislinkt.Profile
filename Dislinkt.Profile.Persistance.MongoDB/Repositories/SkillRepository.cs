using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Persistance.MongoDB.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public SkillRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task AddAsync(Skill skill)
        {
            try
            {
                await _queryExecutor.CreateAsync<SkillEntity>(SkillEntity.ToSkillEntity(skill));

            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }
        }
    }
}
