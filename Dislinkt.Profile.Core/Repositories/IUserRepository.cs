using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<IReadOnlyCollection<User>> GetByUsernameAsync(string username);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAddressAsync(string emailAddress);
        Task<User> GetUserByEmailAddressAndPasswordAsync(string emailAddress, string password);
        Task UpdateUserAsync(User user);
        Task ApproveUserAsync(Guid id);
        Task AddEducationAsync(User user);
        Task AddWorkExperienceAsync(User user);
        Task AddSkillAsync(User user);
        Task AddInterestAsync(User user);
    }
}
