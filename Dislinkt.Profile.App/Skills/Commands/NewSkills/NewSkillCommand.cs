using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;

namespace Dislinkt.Profile.App.Skills.Commands.NewSkills
{
    public class NewSkillCommand : IRequest<Skill>
    {
        public NewSkillCommand(SkillAddedData skillAddedData)
        {
            this.Request = skillAddedData;
        }
        public SkillAddedData Request;
    }
}
