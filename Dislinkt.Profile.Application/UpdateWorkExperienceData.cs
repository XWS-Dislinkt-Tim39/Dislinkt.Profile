using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Application
{
    public class UpdateWorkExperienceData
    {  
        /// <summary>
        ///  id
        /// </summary>
        public Guid Id { get; set; }
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
    }
}
