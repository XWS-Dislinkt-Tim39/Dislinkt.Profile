using Dislinkt.Profile.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IInterestRepository
    {
        Task AddAsync(Interest interest);
        Task<IReadOnlyCollection<Interest>> GetAll();
    }
}
