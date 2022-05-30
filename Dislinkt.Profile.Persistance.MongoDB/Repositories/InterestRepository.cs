using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using MongoDB.Bson;
using System.Text.RegularExpressions;

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

        public async Task<IReadOnlyCollection<Interest>> GetAllAsync()
        {
            var result = await _queryExecutor.GetAll<InterestEntity>();

            return result?.AsEnumerable().Select(i => i.ToInterest()).ToArray() ?? Array.Empty<Interest>();
        }

        public async Task<IReadOnlyCollection<Interest>> GetAllByNameAsync(string name)
        {
            var filter = Builders<InterestEntity>.Filter.Regex("Name", BsonRegularExpression.Create(new Regex(name, RegexOptions.IgnoreCase)));

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable().Select(i => i.ToInterest()).ToArray() ?? Array.Empty<Interest>();
        }

        public async Task<Interest> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<InterestEntity>(id);

            return result?.ToInterest() ?? null;
        }
    }
}
