using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.GetUserInterests
{
    public class GetUserInterestsHandler : IRequestHandler<GetUserInterestsCommand, IReadOnlyCollection<Interest>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IInterestRepository _interestRepository;
        public GetUserInterestsHandler(IUserRepository userRepository, IInterestRepository interestRepository)
        {
            _userRepository = userRepository;
            _interestRepository = interestRepository;
        }
        public async Task<IReadOnlyCollection<Interest>> Handle(GetUserInterestsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Request);

            var interestsIds = user.Interests;
            var interests = new List<Interest>();

            foreach(Guid id in interestsIds)
            {
                var interest = await _interestRepository.GetById(id);

                if (interest != null) interests.Add(interest);
            }

            return interests;
        }
    }
}
