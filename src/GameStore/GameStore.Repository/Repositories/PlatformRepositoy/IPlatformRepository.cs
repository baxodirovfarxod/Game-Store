using GameStore.Dal.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Repository.Repositories.PlatformRepositoy
{
   public interface IPlatformRepository
    {
        Task<Platform> GetByIdAsync(Guid id);
        Task<List<Platform>> GetAllAsync();
        Task<List<Platform>> GetByGameKeyAsync(string key);
        Task<Guid> CreateAsync(Platform platform);
        Task UpdateAsync(Platform platform);
        Task DeleteAsync(Platform platform);
    }
}
