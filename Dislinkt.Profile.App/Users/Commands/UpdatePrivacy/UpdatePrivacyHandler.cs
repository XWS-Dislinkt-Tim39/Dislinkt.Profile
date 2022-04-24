using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.UpdatePrivacy
{
    class UpdatePrivacyHandler : IRequestHandler<UpdatePrivacyCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdatePrivacyHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdatePrivacyCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Request.UserId);

            if (existingUser == null) return false;

            await _userRepository.UpdateUserPrivacyAsync(request.Request.UserId, request.Request.IsPublic);

            return true;
        }
    }
}
