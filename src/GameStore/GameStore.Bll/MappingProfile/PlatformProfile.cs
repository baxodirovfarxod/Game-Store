using AutoMapper;
using GameStore.Bll.Dtos;

namespace GameStore.Bll.MappingProfile;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        CreateMap<PlatformDto, Platform>().ReverseMap();
    }
}
