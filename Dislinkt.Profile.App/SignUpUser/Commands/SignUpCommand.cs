using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;

namespace Dislinkt.Profile.App.SignUpUser.Commands
{
    public class SignUpCommand : IRequest<string>
    {
        public SignUpCommand(string emailAddress, string password)
        {
            this.Request = new SignUpData
            {
                EmailAddress = emailAddress,
                Password = password
            };
        }

        public SignUpData Request;
    }
}
