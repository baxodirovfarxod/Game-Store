using GameStore.Dal;
using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repository.Repositories.GameRepository;

public class GameRepository : IGameRepository
{
    private readonly MainContext MainContext;
    public GameRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Guid> InsertAsync(Game game)
    {
        MainContext.Games.Add(game);
        await MainContext.SaveChangesAsync();
        return game.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var game = await SelectGameByIdAsync(id);
        MainContext.Games.Remove(game);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Game>> SelectAllGamesAsync()
    {
        return await MainContext.Games.ToListAsync();
    }

    public async Task<Game> SelectGameByIdAsync(Guid id)
    {
        var game = await MainContext.Games.FirstOrDefaultAsync(game => game.Id == id);

        if (game == null)
        {
            throw new Exception($"Game with Id {id} not found.");
        }

        return game;
    }

    public async Task<Game> SelectByKeyAsync(string key)
    {
        var game = await MainContext.Games.FirstOrDefaultAsync(game => game.Key == key);

        if (game == null)
        {
            throw new Exception($"Game with Key {key} not found.");
        }

        return game;
    }

    public Task<List<Game>> SelectByPlatformIdAsync(Guid platformId)
    {
        return MainContext.GamePlatforms.Include(g => g.Game)
                                            .Where(g => g.PlatformId == platformId)
                                            .Select(g => g.Game)
                                            .ToListAsync();
    }

    public async Task UpdateAsync(Game game)
    {
        MainContext.Games.Update(game);
        await MainContext.SaveChangesAsync();
    }
}

