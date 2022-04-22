using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace Dislinkt.Profile.Persistance.MongoDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public UserRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        public async Task CreateUser(User user)
        {
           try
           {
                await _queryExecutor.CreateAsync<UserEntity>(ToUserEntity(user));

           } catch(MongoWriteException ex)
           {
                throw ex;
           }

        }

        public async Task<User> GetByEmailAddress(string emailAddress)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress);

            var result = await _queryExecutor.FindAsync<UserEntity>(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }

        public async Task<User> GetByEmailAddressAndPassword(string emailAddress, string password)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress)
                & Builders<UserEntity>.Filter.Eq(u => u.Password, password)
                & Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }

        private UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                IsApproved = user.IsApproved,
                Status = user.Status
            };
        }
       
    }
}
