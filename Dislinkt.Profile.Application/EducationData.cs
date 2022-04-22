using System;

namespace Dislinkt.Profile
{
    class EducationData
    {
        public Guid Id { get; set; }
        public string NameOfSchool { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
