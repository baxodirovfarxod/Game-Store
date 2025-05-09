using GameStore.Dal;
using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repository.Repositories.GenreRepository;

public class GenreRepository : IGenreRepository
{
    private readonly MainContext mainContext;

    public GenreRepository(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<Guid> InsertAsync(Genre genre)
    {
        mainContext.Genres.Add(genre);
        await mainContext.SaveChangesAsync();
        return genre.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var genre = await SelectByIdAsync(id);
        mainContext.Genres.Remove(genre);
    }

    public async Task<List<Genre>> SelectAllAsync()
    {
        return await mainContext.Genres.ToListAsync();
    }

    public async Task<List<Genre>> SelectByGameKeyAsync(string key)
    {
        return await mainContext.GameGenres.Include(g => g.Genre)
                                            .Where(g => g.Game.Key == key)
                                            .Select(g => g.Genre)
                                            .ToListAsync();
    }

    public async Task<Genre> SelectByIdAsync(Guid id)
    {
        var genre =  await mainContext.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre == null)
        {
            throw new Exception($"Genre with Id {id} not found.");
        }

        return genre;
    }

    public async Task<List<Genre>> SelectByParentIdAsync(Guid parentId)
    {
        return await mainContext.Genres
                                .Where(g => g.ParentGenreId == parentId)
                                .ToListAsync();
    }

    public async Task UpdateAsync(Genre genre)
    {
        mainContext.Genres.Update(genre);
        await mainContext.SaveChangesAsync();
    }
}
