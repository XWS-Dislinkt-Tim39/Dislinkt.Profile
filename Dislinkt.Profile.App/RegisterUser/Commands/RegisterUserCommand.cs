using Dislinkt.Profile.Domain.Users;
using MediatR;

namespace Dislinkt.Profile.App.RegisterUser.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterUserCommand(UserData userData)
        {
            Request = userData;
        }
        public UserData Request { get; set; }
        
    }
}
