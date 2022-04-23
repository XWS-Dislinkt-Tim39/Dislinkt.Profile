using Dislinkt.Profile.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        Task<IReadOnlyCollection<Skill>> GetAll();
    }
}
