using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        Task<IReadOnlyCollection<Skill>> GetAllAsync();
        Task<IReadOnlyCollection<Skill>> GetByNameAsync(string name);
        Task<Skill> GetById(Guid id);
    }
}
