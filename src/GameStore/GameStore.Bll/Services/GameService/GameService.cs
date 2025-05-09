using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;
using GameStore.Repository.Repositories.GameRepository;

namespace GameStore.Bll.Services.GameService;

public class GameService : IGameService
{
    private readonly IGameRepository GameRepository;
    private readonly IMapper Mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        GameRepository = gameRepository;
        Mapper = mapper;
    }

    public async Task<Guid> CreateAsync(GameCreateDto game)
    {
        try
        {
            var gameEntity = Mapper.Map<Game>(game);
            gameEntity.Id = Guid.NewGuid();
            return await GameRepository.InsertAsync(gameEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating game: {ex.Message}", ex);
        }
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await GameRepository.DeleteAsync(Guid.Parse(id));
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting game: {ex.Message}", ex);
        }
    }

    public async Task<List<GameGetDto>> GetAllGamesAsync()
    {
        try
        {
            var games = await GameRepository.SelectAllGamesAsync();
            return Mapper.Map<List<GameGetDto>>(games);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting all games: {ex.Message}", ex);
        }
    }

    public async Task<GameGetDto> GetGameByIdAsync(Guid id)
    {
        try
        {
            var game = await GameRepository.SelectGameByIdAsync(id);
            return Mapper.Map<GameGetDto>(game);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting game by ID: {ex.Message}", ex);
        }
    }

    public async Task<List<GameGetDto>> GetByPlatformIdAsync(Guid platformId)
    {
        try
        {
            var games = await GameRepository.SelectByPlatformIdAsync(platformId);
            return Mapper.Map<List<GameGetDto>>(games);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting games by platform ID: {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(UpdateGameDto game)
    {
        try
        {
            await GameRepository.UpdateAsync(Mapper.Map<Game>(game));
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating game: {ex.Message}", ex);
        }
    }

    public async Task<GameGetDto> GetGameByKeyAsync(string key)
    {
        try
        {
            var game = await GameRepository.SelectByKeyAsync(key);
            return Mapper.Map<GameGetDto>(game);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting game by key: {ex.Message}", ex);
        }
    }
}

