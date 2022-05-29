using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IWorkExperienceRepository
    {
        Task<WorkExperience> GetByIdAsync(Guid id);
        Task UpdateWorkExperienceAsync(UpdateWorkExperienceData experience);
    }
}
