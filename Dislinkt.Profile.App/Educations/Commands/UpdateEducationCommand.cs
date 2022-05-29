using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Educations.Commands
{
    public class UpdateEducationCommand : IRequest<Education>
    {
        public UpdateEducationCommand(UpdateEducationData updateEducation)
        {
            this.Request = updateEducation;
        }
        public UpdateEducationData Request;
    }
}
