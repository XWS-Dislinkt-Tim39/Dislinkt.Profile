using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetByEmailAddress(string emailAddress);
    }
}
