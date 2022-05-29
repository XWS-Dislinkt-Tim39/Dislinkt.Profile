using Dislinkt.Profile.Application;
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
    public class EducationRepository : IEducationRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public EducationRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<Education> GetByIdAsync(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<EducationEntity>(id);

            return result?.ToEducation() ?? null;
        }
        public async Task UpdateEducationAsync(UpdateEducationData education)
        {
            var filter = Builders<UserEntity>.Filter.ElemMatch(u => u.Educations, Builders<EducationEntity>.Filter.Eq(u => u.Id, education.Id));

            var update = Builders<UserEntity>.Update.Set(u => u.Educations[-1].NameOfSchool, education.NameOfSchool)
                .Set(u => u.Educations[-1].FieldOfStudy, education.FieldOfStudy)
                .Set(u => u.Educations[-1].Description, education.Description)
                .Set(u => u.Educations[-1].StartDate, education.StartDate)
                .Set(u => u.Educations[-1].EndDate, education.EndDate);



            await _queryExecutor.UpdateAsync(filter, update);
        }

    }
}
