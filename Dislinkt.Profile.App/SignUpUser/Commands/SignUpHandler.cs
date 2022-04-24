using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.SignUpUser.Commands
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public SignUpHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetUserByEmailAddressAndPasswordAsync(request.Request.EmailAddress, request.Request.Password);

            return user;
        }
    }
}
