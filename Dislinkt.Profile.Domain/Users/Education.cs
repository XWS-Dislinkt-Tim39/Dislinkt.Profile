using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class Education
    {
        public Education(Guid id, string nameOfSchool, string fieldOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            Id = id;
            NameOfSchool = nameOfSchool;
            FieldOfStudy = fieldOfStudy;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
        public Guid Id { get; }
        public string NameOfSchool { get; }
        public string FieldOfStudy { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Description { get; }
    }
}
