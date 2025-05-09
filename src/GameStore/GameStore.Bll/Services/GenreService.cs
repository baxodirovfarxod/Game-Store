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
        var genreEntity = mapper.Map<Genre>(genre);
        genreEntity.Id = Guid.NewGuid();
        return await genreRepository.InsertAsync(genreEntity);
    }

    public async Task DeleteAsync(string id)
    {
        await genreRepository.DeleteAsync(Guid.Parse(id));
    }

    public async Task<List<GenreGetDto>> GetAllAsync()
    {
        var genres = await genreRepository.SelectAllAsync();
        return mapper.Map<List<GenreGetDto>>(genres);
    }

    public async Task<List<GenreGetDto>> GetByGameKeyAsync(string key)
    {
        var genres = await genreRepository.SelectByGameKeyAsync(key);
        return mapper.Map<List<GenreGetDto>>(genres);
    }

    public async Task<GenreDto> GetByIdAsync(Guid id)
    {
        var genre = await genreRepository.SelectByIdAsync(id);
        return mapper.Map<GenreDto>(genre);
    }

    public async Task<List<GenreGetDto>> GetByParentIdAsync(Guid parentId)
    {
        var genre = await genreRepository.SelectByParentIdAsync(parentId);
        return mapper.Map<List<GenreGetDto>>(genre);
    }

    public async Task UpdateAsync(GenreDto genre)
    {
        await genreRepository.UpdateAsync(mapper.Map<Genre>(genre));
    }
}
