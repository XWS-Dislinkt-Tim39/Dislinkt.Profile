using MediatR;
using System;

namespace Dislinkt.Profile.App.Users.Commands.ApproveUsers
{
    public class ApproveUserCommand : IRequest<bool>
    {
        public ApproveUserCommand(Guid id)
        {
            this.Request = id;
        }
        public Guid Request;
    }
}
