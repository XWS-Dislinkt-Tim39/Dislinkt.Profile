using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;

namespace Dislinkt.Profile.App.UpdateUser.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserCommand(UpdateUserData updateUserData)
        {
            this.Request = updateUserData;
        }
        public UpdateUserData Request;
    }
}
