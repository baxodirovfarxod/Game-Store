using GameStore.Dal;
using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Repository.Repositories.PlatformRepositoy
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly MainContext _mainContext;

        public PlatformRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<Guid> CreateAsync(Platform platform)
        {
            _mainContext.Platforms.Add(platform);
            await _mainContext.SaveChangesAsync();
            return platform.Id;
        }

        public async Task DeleteAsync(Platform platform)
        {
            var deletePlatform= await GetByIdAsync(platform.Id);
            _mainContext.Platforms.Remove(deletePlatform);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<Platform>> GetAllAsync()
        {
            return await _mainContext.Platforms.ToListAsync();
        }

        public Task<List<Platform>> GetByGameKeyAsync(string key)
        {
            return _mainContext.GamePlatforms.Include(g => g.Platform)
                                             .Where(g => g.Game.Key == key)
                                             .Select(g => g.Platform)
                                             .ToListAsync();
        }

        public async Task<Platform> GetByIdAsync(Guid id)
        {
            var platform = await _mainContext.Platforms.FirstOrDefaultAsync(p => p.Id == id);
            if (platform == null) throw new Exception("Platform not found");
            return platform;
        }

        public async Task UpdateAsync(Platform platform)
        {
            _mainContext.Platforms.Update(platform);
            await _mainContext.SaveChangesAsync();
        }
    }
}
