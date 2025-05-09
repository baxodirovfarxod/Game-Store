using GameStore.Bll.Dtos;
using GameStore.Bll.Services.GenreService.GenreService;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost("post")]
        public async Task<Guid> PostGenre(GenreCreateDto genre)
        {
            return await genreService.CreateAsync(genre);
        }

        [HttpGet("getById/{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<GenreDto> GetGenreById(Guid id)
        {
            return await genreService.GetByIdAsync(id);
        }

        [HttpGet("getAll")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<List<GenreGetDto>> GetAllGenres()
        {
            return await genreService.GetAllAsync();
        }

        [HttpGet("getByGameKey/{key}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<List<GenreGetDto>> GetByGameKeyEndpoint(string key)
        {
            return await genreService.GetByGameKeyAsync(key);
        }

        [HttpGet("getByParentId/{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<List<GenreGetDto>> GetByParentId(Guid id)
        {
            return await genreService.GetByParentIdAsync(id);
        }

        [HttpPut("update")]
        public async Task UpdateGenre(GenreDto genre)
        {
            await genreService.UpdateAsync(genre);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(string id)
        {
            await genreService.DeleteAsync(id);
        }
    }
}
