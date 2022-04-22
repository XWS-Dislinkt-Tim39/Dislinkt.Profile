using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Skills")]
    public class SkillEntity : BaseEntity
    {
        public string Name { get; set; }
        public static SkillEntity ToSkillEntity(Skill skill)
        {
            return new SkillEntity
            {
                Id = skill.Id,
                Name = skill.Name
            };
        }
        public Skill ToSkill()
            => new Skill(this.Id, this.Name);
    }
}
