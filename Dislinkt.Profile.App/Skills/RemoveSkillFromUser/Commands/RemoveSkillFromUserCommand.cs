using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.RemoveSkillFromUser.Commands
{
    public class RemoveSkillFromUserCommand : IRequest<bool>
    {
        public RemoveSkillFromUserCommand(Guid userId, Guid skillId)
        {
            this.UserId = userId;
            this.SkillId = skillId;
        }
        public Guid UserId;
        public Guid SkillId;
    }
}
