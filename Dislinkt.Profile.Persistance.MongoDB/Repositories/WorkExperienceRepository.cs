using Dislinkt.Profile.Application;
using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Persistance.MongoDB.Repositories
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public WorkExperienceRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<WorkExperience> GetByIdAsync(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<WorkExperienceEntity>(id);

            return result?.ToWorkExperience() ?? null;
        }
        public async Task UpdateWorkExperienceAsync(UpdateWorkExperienceData experience)
        {
            var filter = Builders<UserEntity>.Filter.ElemMatch(u => u.WorkExperiences, Builders<WorkExperienceEntity>.Filter.Eq(u=>u.Id,experience.Id));

            var update = Builders<UserEntity>.Update
                .Set(u => u.WorkExperiences[-1].NameOfCompany, experience.NameOfCompany)
                .Set(u => u.WorkExperiences[-1].FieldOfWork, experience.FieldOfWork)
                .Set(u => u.WorkExperiences[-1].Description, experience.Description)
                .Set(u => u.WorkExperiences[-1].StartDate, experience.StartDate)
                .Set(u => u.WorkExperiences[-1].EndDate, experience.EndDate);



            await _queryExecutor.UpdateAsync(filter, update);
        }

    }
}
