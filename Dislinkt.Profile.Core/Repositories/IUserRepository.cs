﻿using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task DeleteUserById(Guid id);

        Task<IReadOnlyList<User>> GetAllAsync();
        Task<IReadOnlyList<User>> GetPublicAsync();
        Task<IReadOnlyCollection<User>> GetByUsernameAsync(string username);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAddressAsync(string emailAddress);
        Task<User> GetByEmailAddressAndUsernameAsync(string emailAddress, string username);
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
        Task<User> GetUserByEmailAddressAndPasswordAsync(string emailAddress, string password);
       
        Task UpdateUserAsync(User user);
        Task UpdateUserPrivacyAsync(Guid id, bool isPublic);
        Task ApproveUserAsync(Guid id);
        Task AddEducationAsync(User user);
        Task AddWorkExperienceAsync(User user);
        Task AddSkillAsync(User user);
        Task AddInterestAsync(User user);
        Task RemoveInterestAsync(Guid userId, Guid interestId);
        Task RemoveSkillAsync(Guid userId, Guid skillId);
    }
}
