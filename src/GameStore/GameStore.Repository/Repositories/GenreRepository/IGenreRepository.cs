using GameStore.Dal.Entities;
using System.Collections.Generic;

namespace GameStore.Repository.Repositories.GenreRepository;

public interface IGenreRepository
{
    Task<Genre> SelectByIdAsync(Guid id);
    Task<List<Genre>> SelectAllAsync();
    Task<List<Genre>> SelectByGameKeyAsync(string key);
    Task<List<Genre>> SelectByParentIdAsync(Guid parentId);
    Task<Guid> InsertAsync(Genre genre);
    Task UpdateAsync(Genre genre);
    Task DeleteAsync(Guid id);
}
