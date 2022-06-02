using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.RemoveInterestFromUser
{
    public class RemoveInterestFromUserHandler : IRequestHandler<RemoveInterestFromUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public RemoveInterestFromUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(RemoveInterestFromUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId);

            if (existingUser == null) return false;


            await _userRepository.RemoveInterestAsync(request.UserId,request.InterestId);

            return true;
        }
    }
}
