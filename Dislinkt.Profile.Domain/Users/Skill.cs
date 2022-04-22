using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class Skill
    {
        public Skill(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
