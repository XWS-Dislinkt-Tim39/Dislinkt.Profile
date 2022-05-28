using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dislinkt.Profile.App.Users.Commands.GetUser
{
    public class GetUserCommand : IRequest<User>
    {
        public GetUserCommand(Guid Id)
        {
            this.Request = Id;
        }
        public Guid Request;
    }
}
