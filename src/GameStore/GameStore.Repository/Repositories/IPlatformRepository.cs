using GameStore.Dal.Entities;
using System.Collections;

namespace GameStore.Repository.Repositories
{
    public interface IPlatformRepository
    {
        Task<Platform> GetByIdAsync(Guid id);
        Task<IEnumerable<Platform>> GetAllAsync();
        Task<IEnumerable<Platform>> GetByGameKeyAsync(string key);
        Task CreateAsync(Platform platform);
        Task UpdateAsync(Platform platform);
        Task DeleteAsync(Platform platform);
    }
}