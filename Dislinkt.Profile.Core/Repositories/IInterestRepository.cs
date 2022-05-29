using Dislinkt.Profile.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Core.Repositories
{
    public interface IInterestRepository
    {
        Task AddAsync(Interest interest);
        Task<IReadOnlyCollection<Interest>> GetAllAsync();
        Task<IReadOnlyCollection<Interest>> GetAllByNameAsync(string name);
        Task<Interest> GetById(Guid id);
    }
}
