using AutoMapper;
using GameStore.Bll.Dtos;

namespace GameStore.Bll.MappingProfile;

public class GenreProfiles : Profile
{
    public GenreProfiles()
    {
        CreateMap<GenreCreateDto, Genre>().ReverseMap();
        CreateMap<GenreDto, Genre>().ReverseMap();
        CreateMap<GenreGetDto, Genre>().ReverseMap();
    }
}
