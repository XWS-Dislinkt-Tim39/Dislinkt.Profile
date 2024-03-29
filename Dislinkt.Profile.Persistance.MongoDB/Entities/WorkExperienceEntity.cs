﻿using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;
using System;
using System.Linq;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Experiences")]
    public class WorkExperienceEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string NameOfCompany { get; set; }
        public string FieldOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Seniority Seniority { get; set; }
        public static WorkExperienceEntity[] ToWorkExperienceEntities(WorkExperience[] workExperiences)
            => workExperiences.Select(p => ToWorkExperienceEntity(p)).ToArray();
        public static WorkExperienceEntity ToWorkExperienceEntity(WorkExperience workExperience)
        {
            return new WorkExperienceEntity
            {
                Id = workExperience.Id,
                UserId = workExperience.UserId,
                NameOfCompany = workExperience.NameOfCompany,
                FieldOfWork = workExperience.FieldOfWork,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate,
                Description = workExperience.Description,
                Seniority = workExperience.Seniority
            };
        }
        public WorkExperience ToWorkExperience()
            => new WorkExperience(this.Id, this.UserId, this.NameOfCompany, this.FieldOfWork, this.StartDate, this.EndDate, this.Description, this.Seniority);
    }
}
