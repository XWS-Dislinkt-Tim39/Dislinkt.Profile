using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.Commands.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsCommand, IReadOnlyCollection<Skill>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<IReadOnlyCollection<Skill>> Handle(GetAllSkillsCommand request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllAsync();
        }
    }
}
