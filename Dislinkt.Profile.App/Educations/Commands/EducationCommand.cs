using MediatR;

namespace Dislinkt.Profile.App.Educations.Commands
{
    public class EducationCommand : IRequest<bool>
    {
        public EducationCommand(EducationData educationData)
        {
            this.Request = educationData;
        }
        public EducationData Request { get; set; }
    }
}
