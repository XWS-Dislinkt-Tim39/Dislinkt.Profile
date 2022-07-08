using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class WorkExperience
    {
        public WorkExperience(Guid id, Guid userId, string nameOfCompany, string fieldOfWork, DateTime startDate, DateTime endDate, string description, Seniority seniority)
        {
            Id = id;
            UserId = userId;
            NameOfCompany = nameOfCompany;
            FieldOfWork = fieldOfWork;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Seniority = seniority;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public string NameOfCompany { get; }
        public string FieldOfWork { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Description { get; }
        public Seniority Seniority { get; }
    }
}
