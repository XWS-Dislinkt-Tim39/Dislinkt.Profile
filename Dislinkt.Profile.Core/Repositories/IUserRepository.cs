using Dislinkt.Profile.Domain.Users;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetByEmailAddress(string emailAddress);
        Task<User> GetByEmailAddressAndPassword(string emailAddress, string password);
    }
}
