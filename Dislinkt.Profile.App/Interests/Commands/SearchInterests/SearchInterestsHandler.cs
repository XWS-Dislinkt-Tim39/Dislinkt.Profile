using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.SearchInterests
{
    public class SearchInterestsHandler : IRequestHandler<SearchInterestsCommand, IReadOnlyCollection<Interest>>
    {
        private readonly IInterestRepository _interestsRepository;
        public SearchInterestsHandler(IInterestRepository interestRepository)
        {
            _interestsRepository = interestRepository;
        }
        public async Task<IReadOnlyCollection<Interest>> Handle(SearchInterestsCommand request, CancellationToken cancellationToken)
        {
            return await _interestsRepository.GetAllByNameAsync(request.Request);
        }
    }
}
