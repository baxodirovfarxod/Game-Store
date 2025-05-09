using GameStore.Dal.Entities;

namespace GameStore.Repository.Repositories.GameRepository;

public interface IGameRepository
{
    Task<Game> SelectByKeyAsync(string key);
    Task<Game> SelectGameByIdAsync(Guid id);
    Task<List<Game>> SelectAllGamesAsync();
    Task<List<Game>> SelectByPlatformIdAsync(Guid platformId);
    Task<Guid> InsertAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(Guid id);
}
