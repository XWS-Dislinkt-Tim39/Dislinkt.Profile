using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.GetAllInterests
{
    public class GetAllInterestsHandler : IRequestHandler<GetAllInterestsCommand, IReadOnlyCollection<Interest>>
    {
        private readonly IInterestRepository _interestsRepository;

        public GetAllInterestsHandler(IInterestRepository interestsRepository)
        {
            _interestsRepository = interestsRepository;
        }

        public async Task<IReadOnlyCollection<Interest>> Handle(GetAllInterestsCommand request, CancellationToken cancellationToken)
        {
            return await _interestsRepository.GetAllAsync();
        }
    }
}
