using Dislinkt.Profile.Application;
using MediatR;

namespace Dislinkt.Profile.App.Skills.Commands.NewSkills
{
    public class NewSkillCommand : IRequest<bool>
    {
        public NewSkillCommand(SkillAddedData skillAddedData)
        {
            this.Request = skillAddedData;
        }
        public SkillAddedData Request;
    }
}
