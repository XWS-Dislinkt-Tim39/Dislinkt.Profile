using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Users.Commands.GetAllUsers
{
    public class GetAllUsersCommand : IRequest<IReadOnlyCollection<User>>
    {
    }
}
