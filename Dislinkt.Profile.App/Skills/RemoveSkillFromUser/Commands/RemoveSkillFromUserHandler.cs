using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.RemoveSkillFromUser.Commands
{
    public class RemoveSkillFromUserHandler : IRequestHandler<RemoveSkillFromUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public RemoveSkillFromUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(RemoveSkillFromUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId);

            if (existingUser == null) return false;


            await _userRepository.RemoveSkillAsync(request.UserId, request.SkillId);

            return true;
        }
    }
}
