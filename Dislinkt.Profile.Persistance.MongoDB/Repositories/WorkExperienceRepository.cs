using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Common;
using Dislinkt.Profile.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task UpdateWorkExperienceAsync(WorkExperience experience)
        {
            /*var filter = Builders<UserEntity>.Filter.ElemMatch(u => u.WorkExperiences, Builders<WorkExperienceEntity>.Filter.Eq(u=>u.Id,experience.Id));
            
            var filter1 = Builders<WorkExperienceEntity>.Filter.Eq(u=> u.UserId,filter.Id);
            var update = Builders<WorkExperienceEntity>.Update.Set(u => u.NameOfCompany, experience.NameOfCompany)
                .Set(u => u.FieldOfWork, experience.FieldOfWork)
                .Set(u => u.Description, experience.Description)
                .Set(u => u.StartDate, experience.StartDate)
                .Set(u => u.EndDate, experience.EndDate);



            await _queryExecutor.UpdateAsync(filter, update);*/
        }

    }
}
