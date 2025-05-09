using GameStore.Dal;
using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Repository.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly MainContext _mainContext;

    public PlatformRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task CreateAsync(Platform platform)
    {
        await _mainContext.Platforms.AddAsync(platform);
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Platform platform)
    {
        await _mainContext.Platforms
            .Where(p => p.Id == platform.Id)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Platform>> GetAllAsync()
    {
        var platforms = await _mainContext.Platforms
            .AsNoTracking()
            .ToListAsync();
        return platforms;
    }

    public async Task<IEnumerable<Platform>> GetByGameKeyAsync(string key)
    {
        var platforms = await _mainContext.Platforms
            .Where(p => p.GamePlatforms.Any(gp => gp.Game.Key == key))  
            .AsNoTracking()
            .ToListAsync();

        return platforms;
    }



    public async Task<Platform> GetByIdAsync(Guid id)
    {
        var platform = await _mainContext.Platforms
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
        return platform;
    }

    public async Task UpdateAsync(Platform platform)
    {
        var existing = await _mainContext.Platforms
            .FirstOrDefaultAsync(p => p.Id == platform.Id);

        if (existing is null) return;              

        existing.Type = platform.Type;         

        await _mainContext.SaveChangesAsync();      
    }

}
