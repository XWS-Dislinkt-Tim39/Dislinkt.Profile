using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dislinkt.Profile.App.Skills.Commands.GetUserSkills.Commands
{
    public class GetUserSkillsCommand : IRequest<IReadOnlyCollection<Skill>>
    {
        public GetUserSkillsCommand(Guid Id)
        {
            this.Request = Id;
        }
        public Guid Request;
    }
}
