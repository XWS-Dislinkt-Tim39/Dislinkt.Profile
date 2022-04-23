using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.Commands.SearchSkills
{
    public class SearchSkillsHandler : IRequestHandler<SearchSkillsCommand, IReadOnlyCollection<Skill>>
    {
        private readonly ISkillRepository _skillRepository;

        public SearchSkillsHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IReadOnlyCollection<Skill>> Handle(SearchSkillsCommand request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetByNameAsync(request.Request);
        }
    }
}
