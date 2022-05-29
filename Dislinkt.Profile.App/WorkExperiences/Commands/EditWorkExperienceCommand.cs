using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.WorkExperiences.Commands
{
    public class EditWorkExperienceCommand: IRequest<WorkExperience>
    {
        public EditWorkExperienceCommand(UpdateWorkExperienceData updateWorkExperience)
        {
            this.Request = updateWorkExperience;
        }
        public UpdateWorkExperienceData Request;
    }
}
