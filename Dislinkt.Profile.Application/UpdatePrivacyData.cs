using System;

namespace Dislinkt.Profile.Application
{
    public class UpdatePrivacyData
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Is private user
        /// </summary>
        public bool IsPublic { get; set; }
    }
}
