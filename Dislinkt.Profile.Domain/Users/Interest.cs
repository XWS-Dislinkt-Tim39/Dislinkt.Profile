using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class Interest
    {
        public Interest(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
