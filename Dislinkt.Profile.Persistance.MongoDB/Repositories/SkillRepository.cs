using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

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

        public async Task<IReadOnlyCollection<Skill>> GetAll()
        {
            var result = await _queryExecutor.GetAll<SkillEntity>();

            return result?.AsEnumerable().Select(s => s.ToSkill()).ToArray() ?? Array.Empty<Skill>();
        }
    }
}
