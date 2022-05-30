using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.Commands.GetUserSkills.Commands
{
    public class GetUserSkillsHandler : IRequestHandler<GetUserSkillsCommand, IReadOnlyCollection<Skill>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        public GetUserSkillsHandler(IUserRepository userRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }
        public async Task<IReadOnlyCollection<Skill>> Handle(GetUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Request);

            var skillsIds = user.Skills;
            var skills = new List<Skill>();

            foreach(Guid id in skillsIds)
            {
                var skill = await _skillRepository.GetById(id);

                if (skill != null) skills.Add(skill);
            }

            return skills;
        }
    }
}
