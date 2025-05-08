using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;

namespace GameStore.Bll.MappingProfile;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameDto>();

        CreateMap<GameDto, Game>()
            .ForMember(dest => dest.GameGenres, opt => opt.Ignore())
            .ForMember(dest => dest.GamePlatforms, opt => opt.Ignore());
    }
}
