using Dislinkt.Profile.Application;
using MediatR;

namespace Dislinkt.Profile.App.Interests.Commands.NewInterest
{
    public class NewInterestCommand : IRequest<bool>
    {
        public NewInterestCommand(InterestAddedData interestAddedData)
        {
            this.Request = interestAddedData;
        }
        public InterestAddedData Request;
    }
}
