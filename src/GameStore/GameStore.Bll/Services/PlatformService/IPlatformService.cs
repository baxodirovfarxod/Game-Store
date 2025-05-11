using GameStore.Bll.Dtos;

namespace GameStore.Bll.Services.PlatformService
{
    public interface IPlatformService
    {
        Task<PlatformDto> GetByIdAsync(Guid id);
        Task<List<PlatformDto>> GetAllAsync();
        Task<List<PlatformDto>> GetByGameKeyAsync(string key);
        Task<Guid> CreateAsync(PlatformCreateDto dto);
        Task UpdateAsync(PlatformCreateDto dto);
        Task DeleteAsync(Guid id);
    }
}