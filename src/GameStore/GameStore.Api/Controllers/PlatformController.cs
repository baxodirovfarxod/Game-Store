using GameStore.Bll.Dtos;
using GameStore.Bll.Services;
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

        [HttpPost("Add new platform")]
        public async Task CreatePlatform([FromBody] PlatformCreateDto platformCreateDto)
        {
            if (platformCreateDto == null)
            {
                 BadRequest("Platform data is null");
            }

            await _platformService.CreateAsync(platformCreateDto);
            Ok("Platform created successfully");
        }

        [HttpGet("Get all platforms")]
        public async Task<IActionResult> GetAllPlatforms()
        {
            var platforms = await _platformService.GetAllAsync();
            if (platforms == null || !platforms.Any())
            {
                return NotFound("No platforms found");
            }
            return Ok(platforms);
        }

        [HttpGet("Get platform by id")]
        public async Task<IActionResult> GetPlatformById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid platform ID");
            }

            var platform = await _platformService.GetByIdAsync(id);

            if (platform == null)
            {
                return NotFound("Platform not found");
            }

            return Ok(platform);
        }

        [HttpGet("Get platforms by game key")]
        public async Task<IActionResult> GetPlatformsByGameKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest("Invalid game key");
            }
            var platforms = await _platformService.GetByGameKeyAsync(key);
            if (platforms == null || !platforms.Any())
            {
                return NotFound("No platforms found for the given game key");
            }
            return Ok(platforms);
        }

        [HttpPut("Update platform")]
        public async Task<IActionResult> UpdatePlatform([FromBody] PlatformDto platformDto)
        {
            if (platformDto == null)
            {
                return BadRequest("Platform data is null");
            }

            var existingPlatform = await _platformService.GetByIdAsync(platformDto.Id);
            if (existingPlatform == null)
            {
                return NotFound("Platform not found");
            }
            await _platformService.UpdateAsync(platformDto);
            return Ok("Platform updated successfully");
        }

        [HttpDelete("Delete platform")]
        public async Task<IActionResult> DeletePlatform(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid platform ID");
            }

            var platform = await _platformService.GetByIdAsync(id);
            if (platform == null)
            {
                return NotFound("Platform not found");
            }
            await _platformService.DeleteAsync(id);
            return Ok("Platform deleted successfully");
        }
    }
}
