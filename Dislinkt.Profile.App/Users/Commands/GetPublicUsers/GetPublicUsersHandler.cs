using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.GetPublicUsers
{
    public class GetPublicUsersHandler : IRequestHandler<GetPublicUsersCommand, IReadOnlyCollection<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetPublicUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyCollection<User>> Handle(GetPublicUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetPublicAsync();
        }
    }
}
