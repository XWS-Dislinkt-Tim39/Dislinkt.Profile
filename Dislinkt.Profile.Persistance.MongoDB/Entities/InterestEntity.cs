using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Interests")]
    public class InterestEntity : BaseEntity
    {
        public string Name { get; set; }
        public Interest ToInterest()
            => new Interest(this.Id, this.Name);
        public static InterestEntity ToInterestEntity(Interest interest)
        {
            return new InterestEntity
            {
                Id = interest.Id,
                Name = interest.Name
            };
        }
    }
}
