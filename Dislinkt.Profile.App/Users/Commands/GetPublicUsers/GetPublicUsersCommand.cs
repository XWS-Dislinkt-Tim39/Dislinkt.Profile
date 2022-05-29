using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.GetPublicUsers
{
    public class GetPublicUsersCommand : IRequest<IReadOnlyCollection<User>>
    {
    }
}
