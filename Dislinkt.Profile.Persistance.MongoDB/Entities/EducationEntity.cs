using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;
using System;
using System.Linq;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Educations")]
    public class EducationEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string NameOfSchool { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public static EducationEntity[] ToEducationEntities(Education[] educations)
            => educations.Select(p => ToEducationEntity(p)).ToArray();
        public static EducationEntity ToEducationEntity(Education education)
        {
            return new EducationEntity
            {
                Id = education.Id,
                UserId = education.UserId,
                NameOfSchool = education.NameOfSchool,
                FieldOfStudy = education.FieldOfStudy,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Description = education.Description
            };
        }
        public Education ToEducation()
        {
            return new Education(this.Id, this.UserId, this.NameOfSchool, this.FieldOfStudy, this.StartDate, this.EndDate, this.Description);
        }
    }
}
