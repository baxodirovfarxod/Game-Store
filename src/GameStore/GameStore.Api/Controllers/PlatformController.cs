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
            try
            {
                if (platform == null) throw new ArgumentNullException(nameof(platform));
                await _platformService.CreateAsync(platform);
                return Ok("Platform created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating platform: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
                await _platformService.DeleteAsync(id);
                return Ok("Platform deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting platform: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var platforms = await _platformService.GetAllAsync();
                return Ok(platforms);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting platforms: {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
                var platform = await _platformService.GetByIdAsync(id);
                return Ok(platform);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting platform by ID: {ex.Message}");
            }
        }
    }
}
