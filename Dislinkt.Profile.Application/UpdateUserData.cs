using Dislinkt.Profile.Domain.Users;
using System;

namespace Dislinkt.Profile.Application
{
    public class UpdateUserData
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email address
        /// </summary>
        public string Biography { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public GenderData Gender { get; set; }
        /// <summary>
        /// Seniority
        /// </summary>
        public Seniority Seniority { get; set; }
    }
}
