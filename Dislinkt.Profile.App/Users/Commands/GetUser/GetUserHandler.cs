using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       

        public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {

            var existingUser = await _userRepository.GetByIdAsync(request.Request);

            if (existingUser == null) return null;




            return existingUser;
        }
    }
}
