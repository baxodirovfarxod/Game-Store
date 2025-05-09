using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;

namespace GameStore.Bll.MappingProfile;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameCreateDto, Game>()
       .ForMember(dest => dest.GameGenres, opt => opt.Ignore())
       .ForMember(dest => dest.GamePlatforms, opt => opt.Ignore())
       .ReverseMap();

        CreateMap<Game, GameGetDto>();
    }
}
