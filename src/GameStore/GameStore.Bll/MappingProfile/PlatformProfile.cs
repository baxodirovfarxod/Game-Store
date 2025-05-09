using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;

namespace GameStore.Bll.MappingProfile;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        CreateMap<PlatformDto, Platform>().ReverseMap();
        CreateMap<PlatformCreateDto, Platform>().ReverseMap();
    }
}
