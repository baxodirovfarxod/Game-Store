using GameStore.Bll.Dtos;
using GameStore.Bll.Services.GameService;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService GameService;

        public GameController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpPost("post")]
        public async Task<Guid> PostGame(GameCreateDto game)
        {
            return await GameService.CreateAsync(game);
        }

        [HttpPut("update")]
        public async Task UpdateGame(UpdateGameDto game)
        {
            await GameService.UpdateAsync(game);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(string id)
        {
            await GameService.DeleteAsync(id);
        }


        [HttpGet("getById/{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<GameGetDto> GetGameById(Guid id)
        {
            return await GameService.GetGameByIdAsync(id);
        }

        [HttpGet("getAll")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<List<GameGetDto>> GetAllGames()
        {
            return await GameService.GetAllGamesAsync();
        }

        [HttpGet("getByPlatformId/{platformId}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<List<GameGetDto>> GetByPlatformId(Guid platformId)
        {
            return await GameService.GetByPlatformIdAsync(platformId);
        }

        [HttpGet("getByKey/{key}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<GameGetDto> GetByKey(string key)
        {
            return await GameService.GetGameByKeyAsync(key);
        }
    }
}
