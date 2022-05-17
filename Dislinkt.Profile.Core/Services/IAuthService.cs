using Dislinkt.Profile.Domain.Users;

namespace Dislinkt.Profile.Core.Services
{
    public interface IAuthService
    {
        string CreateToken(User user);
    }
}
