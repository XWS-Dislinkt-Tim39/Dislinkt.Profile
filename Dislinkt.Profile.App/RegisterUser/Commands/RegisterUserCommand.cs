using MediatR;

namespace Dislinkt.Profile.App.RegisterUser.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterUserCommand(UserData userData)
        {
            Request = userData;
        }
        public UserData Request { get; set; }
        
    }
}
