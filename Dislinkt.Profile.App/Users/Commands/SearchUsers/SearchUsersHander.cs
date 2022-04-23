using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Users.Commands.SearchUsers
{
    public class SearchUsersHander : IRequestHandler<SearchUsersCommand, IReadOnlyCollection<User>>
    {
        private readonly IUserRepository _userRepository;

        public SearchUsersHander(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<User>> Handle(SearchUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByUsernameAsync(request.Request);
        }
    }
}
