using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.RemoveInterestFromUser
{
    public class RemoveInterestFromUserCommand : IRequest<bool>
    {
        public RemoveInterestFromUserCommand(Guid userId,Guid interestId)
        {
            this.UserId = userId;
            this.InterestId = interestId;
        }
        public Guid UserId;
        public Guid InterestId;
    }
}
