using Dislinkt.Profile.Application;
using MediatR;

namespace Dislinkt.Profile.App.Interests.Commands.AddInterestToUser
{
    public class AddInterestToUserCommand : IRequest<bool>
    {
        public AddInterestToUserCommand(InterestData interestData)
        {
            this.Request = interestData;
        }
        public InterestData Request;
    }
}
