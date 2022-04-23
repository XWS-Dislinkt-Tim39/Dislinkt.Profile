using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Interests.Commands.SearchInterests
{
    public class SearchInterestsCommand : IRequest<IReadOnlyCollection<Interest>>
    {
        public SearchInterestsCommand(string name)
        {
            this.Request = name;
        }
        public string Request;
    }
}
