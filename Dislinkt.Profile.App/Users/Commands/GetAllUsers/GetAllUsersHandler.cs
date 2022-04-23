using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersCommand, IReadOnlyCollection<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyCollection<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
