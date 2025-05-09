using GameStore.Bll.Dtos;

namespace GameStore.Bll.Services.GameService;

public interface IGameService
{
    Task<GameGetDto> GetGameByIdAsync(Guid id);
    Task<List<GameGetDto>> GetAllGamesAsync();
    Task<List<GameGetDto>> GetByPlatformIdAsync(Guid platformId);
    Task<GameGetDto> GetGameByKeyAsync(string key);
    Task<Guid> CreateAsync(GameCreateDto game);
    Task UpdateAsync(UpdateGameDto game);
    Task DeleteAsync(string id);
}
