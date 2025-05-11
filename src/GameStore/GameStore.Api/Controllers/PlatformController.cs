using GameStore.Bll.Dtos;
using GameStore.Bll.Services.PlatformService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlatformCreateDto platform)
        {
                await _platformService.CreateAsync(platform);
                return Ok("Platform created successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
                await _platformService.DeleteAsync(id);
                return Ok("Platform deleted successfully");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
                var platforms = await _platformService.GetAllAsync();
                return Ok(platforms);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
                var platform = await _platformService.GetByIdAsync(id);
                return Ok(platform);
        }
    }
}
