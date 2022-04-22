using Dislinkt.Profile.Application;
using MediatR;

namespace Dislinkt.Profile.App.Skills.Commands.AddSkillToUser
{
    public class AddSkillToUserCommand : IRequest<bool>
    {
        public AddSkillToUserCommand(SkillData skillData)
        {
            this.Request = skillData;
        }
        public SkillData Request;
    }
}
