using System;
using Dislinkt.Profile.Domain.Users;

namespace Dislinkt.Profile.Application
{
    public class WorkExperienceData
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Name of company
        /// </summary>
        public string NameOfCompany { get; set; }
        /// <summary>
        /// Field of work
        /// </summary>
        public string FieldOfWork { get; set; }
        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Seniority
        /// </summary>
        public Seniority Seniority { get; set; }
    }
}
