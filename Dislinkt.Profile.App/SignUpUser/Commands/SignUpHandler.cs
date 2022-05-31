using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Core.Services;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dislinkt.Profile.Domain.Users;

namespace Dislinkt.Profile.App.SignUpUser.Commands
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, UserDetails>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public SignUpHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<UserDetails> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAndPasswordAsync(request.Request.Username, BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(request.Request.Password))));

            if (user == null) return null;

            var token = _authService.CreateToken(user);
            var details = new UserDetails(user, token);

            return details;
        }
    }
}
