using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.ApproveUsers
{
    public class ApproveUserHandler : IRequestHandler<ApproveUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public ApproveUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(ApproveUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Request);

            if (existingUser == null) return false;

            await _userRepository.ApproveUserAsync(request.Request);

            return true;
        }
    }
}
