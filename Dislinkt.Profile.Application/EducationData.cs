﻿using System;

namespace Dislinkt.Profile
{
    public class EducationData
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Name of school
        /// </summary>
        public string NameOfSchool { get; set; }
        /// <summary>
        /// Field of study
        /// </summary>
        public string FieldOfStudy { get; set; }
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
    }
}
