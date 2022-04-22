using Dislinkt.Profile.Application;
using MediatR;

namespace Dislinkt.Profile.App.WorkExperiences
{
    public class WorkExperienceCommand : IRequest<bool>
    {
        public WorkExperienceCommand(WorkExperienceData workExperienceData)
        {
            this.Request = workExperienceData;
        }
        public WorkExperienceData Request;
    }
}
