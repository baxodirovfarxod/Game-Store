using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;

namespace GameStore.Bll.Services;

public interface IGenreService
{
    Task<GenreDto> GetByIdAsync(Guid id);
    Task<List<GenreGetDto>> GetAllAsync();
    Task<List<GenreGetDto>> GetByGameKeyAsync(string key);
    Task<List<GenreGetDto>> GetByParentIdAsync(Guid parentId);
    Task<Guid> CreateAsync(GenreCreateDto genre);
    Task UpdateAsync(GenreDto genre);
    Task DeleteAsync(string id);
}
