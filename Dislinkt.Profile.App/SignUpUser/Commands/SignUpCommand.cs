using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;

namespace Dislinkt.Profile.App.SignUpUser.Commands
{
    public class SignUpCommand : IRequest<UserDetails>
    {
        public SignUpCommand(string username, string password)
        {
            this.Request = new SignUpData
            {
                Username = username,
                Password = password
            };
        }

        public SignUpData Request;
    }
}
