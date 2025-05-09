using GameStore.Bll.Dtos;
using System.Collections;

namespace GameStore.Bll.Services
{
    public interface IPlatformService
    {
        Task<PlatformDto> GetByIdAsync(Guid id);
        Task<IEnumerable<PlatformDto>> GetAllAsync();
        Task<IEnumerable<PlatformDto>> GetByGameKeyAsync(string key);
        Task CreateAsync(PlatformCreateDto dto);
        Task UpdateAsync(PlatformDto dto);
        Task DeleteAsync(Guid id);
    }
}