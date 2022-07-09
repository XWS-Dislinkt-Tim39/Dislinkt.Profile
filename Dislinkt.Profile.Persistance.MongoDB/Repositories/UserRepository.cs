using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

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

        public async Task RemoveInterestAsync(Guid userId,Guid interestId)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id,userId);

            var update = Builders<UserEntity>.Update.Pull(u => u.Interests, interestId);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task AddSkillAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.Skills, user.Skills);

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task RemoveSkillAsync(Guid userId, Guid skillId)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, userId);

            var update = Builders<UserEntity>.Update.Pull(u => u.Skills, skillId);

            await _queryExecutor.UpdateAsync(filter, update);
        }


        public async Task AddWorkExperienceAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.WorkExperiences, WorkExperienceEntity.ToWorkExperienceEntities(user.WorkExperiences));

            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task ApproveUserAsync(Guid id)
        {

            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<UserEntity>.Update.Set(u => u.IsApproved, true);

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

        public async Task<IReadOnlyList<User>> GetPublicAsync()
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true) &
                Builders<UserEntity>.Filter.Eq(u => u.Status, VisibilityStatus.Public);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable().Select(u => u.ToUser()).ToArray() ?? Array.Empty<User>();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable().Select(u => u.ToUser()).ToArray() ?? Array.Empty<User>();
        }

        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }
        public async Task<User> GetByEmailAddressAndUsernameAsync(string emailAddress, string username)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress)
                & Builders<UserEntity>.Filter.Eq(u => u.Username, username);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }
        public async Task<User> GetByIdAsync(Guid id)
        {

            var result = await _queryExecutor.FindByIdAsync<UserEntity>(id);

            return result?.ToUser() ?? null;
        }

        public async Task<IReadOnlyCollection<User>> GetByUsernameAsync(string username)
        {
            var filter = Builders<UserEntity>.Filter.Regex("Username", BsonRegularExpression.Create(new Regex(username, RegexOptions.IgnoreCase)));

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.Select(u => u.ToUser()).ToArray() ?? Array.Empty<User>();
        }

        public async Task<User> GetUserByEmailAddressAndPasswordAsync(string emailAddress, string password)
        { 
            var filter = Builders<UserEntity>.Filter.Eq(u => u.EmailAddress, emailAddress)
                & Builders<UserEntity>.Filter.Eq(u => u.Password, password)
                & Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.EmailAddress == emailAddress)?.ToUser() ?? null;
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Username, username)
                & Builders<UserEntity>.Filter.Eq(u => u.Password, password)
                & Builders<UserEntity>.Filter.Eq(u => u.IsApproved, true);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault(u => u.Username == username)?.ToUser() ?? null;
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, user.Id);

            var update = Builders<UserEntity>.Update.Set(u => u.FirstName, user.FirstName)
                .Set(u => u.LastName, user.LastName)
                .Set(u => u.EmailAddress, user.EmailAddress)
                .Set(u => u.Gender, user.Gender)
                .Set(u => u.PhoneNumber, user.PhoneNumber)
                .Set(u => u.DateOfBirth, user.DateOfBirth)
                .Set(u => u.City, user.City)
                .Set(u => u.Country, user.Country)
                .Set(u => u.Address, user.Address)
                .Set(u => u.Biography, user.Biography)
                .Set(u => u.Seniority, user.Seniority);



            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task UpdateUserPrivacyAsync(Guid id, bool isPublic)
        {
            var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<UserEntity>.Update.Set(u => u.Status, isPublic ? VisibilityStatus.Public : VisibilityStatus.Private);

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
                Status = user.Status,
                Seniority = user.Seniority
            };
        }

       
    }
}
