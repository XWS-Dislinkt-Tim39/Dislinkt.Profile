using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Dislinkt.Profile.Persistance.MongoDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public UserRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task AddEducationAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.Educations, EducationEntity.ToEducationEntities(user.Educations));

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task AddInterestAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.Interests, user.Interests);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task AddSkillAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.Skills, user.Skills);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task AddWorkExperienceAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.WorkExperiences, WorkExperienceEntity.ToWorkExperienceEntities(user.WorkExperiences));

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task CreateUserAsync(User user)
        {
           try
           {
                await _queryExecutor.CreateAsync<UserEntity>(ToUserEntity(user));

           } catch(MongoWriteException ex)
           {
                throw ex;
           }

        }

        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress);

            var result = await _queryExecutor.FindAsync<UserEntity>(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }

        public async Task<User> GetById(Guid id)
        {

            var result = await _queryExecutor.FindByIdAsync<UserEntity>(id);

            return result?.ToUser() ?? null;
        }

        public async Task<User> GetUserByEmailAddressAndPasswordAsync(string emailAddress, string password)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress)
                & Builders<UserEntity>.Filter.Eq(u => u.Password, password)
                & Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.FirstName, user.FirstName)
                .Set(u => u.LastName, user.LastName)
                .Set(u => u.EmailAddress, user.EmailAddress)
                .Set(u => u.Gender, user.Gender)
                .Set(u => u.PhoneNumber, user.PhoneNumber)
                .Set(u => u.DateOfBirth, user.DateOfBirth);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        private UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
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
