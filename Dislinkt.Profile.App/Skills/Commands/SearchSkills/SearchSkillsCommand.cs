using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Skills.Commands.SearchSkills
{
    public class SearchSkillsCommand : IRequest<IReadOnlyCollection<Skill>>
    {
        public SearchSkillsCommand(string name)
        {
            this.Request = name;
        }
        public string Request;
    }
}
