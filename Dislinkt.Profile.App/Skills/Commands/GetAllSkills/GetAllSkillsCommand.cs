using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Skills.Commands.GetAllSkills
{
    public class GetAllSkillsCommand : IRequest<IReadOnlyCollection<Skill>>
    {
    }
}
