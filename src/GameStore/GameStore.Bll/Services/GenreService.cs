using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;
using GameStore.Repository.Repositories.GenreRepository;

namespace GameStore.Bll.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository genreRepository;
    private readonly IMapper mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        this.genreRepository = genreRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> CreateAsync(GenreCreateDto genre)
    {
        try
        {
            var genreEntity = mapper.Map<Genre>(genre);
            genreEntity.Id = Guid.NewGuid();
            return await genreRepository.InsertAsync(genreEntity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating genre: {ex.Message}", ex);
        }
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await genreRepository.DeleteAsync(Guid.Parse(id));
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting genre: {ex.Message}", ex);
        }
    }

    public async Task<List<GenreGetDto>> GetAllAsync()
    {
        try
        {
            var genres = await genreRepository.SelectAllAsync();
            return mapper.Map<List<GenreGetDto>>(genres);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting all genres: {ex.Message}", ex);
        }
    }

    public async Task<List<GenreGetDto>> GetByGameKeyAsync(string key)
    {
        try
        {
            var genres = await genreRepository.SelectByGameKeyAsync(key);
            return mapper.Map<List<GenreGetDto>>(genres);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting genres by game key '{key}': {ex.Message}", ex);
        }
    }

    public async Task<GenreDto> GetByIdAsync(Guid id)
    {
        try
        {
            var genre = await genreRepository.SelectByIdAsync(id);
            return mapper.Map<GenreDto>(genre);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting genre by id '{id}': {ex.Message}", ex);
        }
    }

    public async Task<List<GenreGetDto>> GetByParentIdAsync(Guid parentId)
    {
        try
        {
            var genre = await genreRepository.SelectByParentIdAsync(parentId);
            return mapper.Map<List<GenreGetDto>>(genre);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting genres by parent id '{parentId}': {ex.Message}", ex);
        }
    }

    public async Task UpdateAsync(GenreDto genre)
    {
        try
        {
            await genreRepository.UpdateAsync(mapper.Map<Genre>(genre));
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating genre: {ex.Message}", ex);
        }
    }
}