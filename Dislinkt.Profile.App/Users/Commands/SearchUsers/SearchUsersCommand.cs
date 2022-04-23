using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Users.Commands.SearchUsers
{
    public class SearchUsersCommand : IRequest<IReadOnlyCollection<User>>
    {
        public SearchUsersCommand(string username)
        {
            this.Request = username;
        }
        public string Request;
    }
}
