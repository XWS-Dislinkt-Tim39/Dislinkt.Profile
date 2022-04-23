using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Interests.Commands.GetAllInterests
{
    public class GetAllInterestsCommand : IRequest<IReadOnlyCollection<Interest>>
    {
    }
}
