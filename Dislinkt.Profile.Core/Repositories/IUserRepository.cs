using Dislinkt.Profile.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User> GetById(Guid id);
        Task<User> GetByEmailAddressAsync(string emailAddress);
        Task<User> GetUserByEmailAddressAndPasswordAsync(string emailAddress, string password);
        Task UpdateUserAsync(User user);
        Task AddEducationAsync(User user);
    }
}
