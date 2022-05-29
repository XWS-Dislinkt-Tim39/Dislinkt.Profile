using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Interests.Commands.GetUserInterests
{
    public class GetUserInterestsCommand : IRequest<IReadOnlyCollection<Interest>>
    {
        public GetUserInterestsCommand(Guid id)
        {
            this.Request = id;
        }
        public Guid Request;
    }
}
