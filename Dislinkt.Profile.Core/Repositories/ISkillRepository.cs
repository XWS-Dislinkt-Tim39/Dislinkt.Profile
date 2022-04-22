using Dislinkt.Profile.Domain.Users;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
    }
}
