using GameStore.Bll.MappingProfile;
using GameStore.Bll.Services.GameService;
using GameStore.Bll.Services.GenreService.GenreService;
using GameStore.Bll.Services.PlatformService;
using GameStore.Repository.Repositories.GameRepository;
using GameStore.Repository.Repositories.GenreRepository;
using GameStore.Repository.Repositories.PlatformRepositoy;

namespace GameStore.Api.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching();
        builder.Services.AddAutoMapper(typeof(GenreProfiles));
        builder.Services.AddAutoMapper(typeof(GameProfile));
        builder.Services.AddAutoMapper(typeof(PlatformProfile));

        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();

        builder.Services.AddScoped<IGameRepository, GameRepository>();
        builder.Services.AddScoped<IGameService, GameService>();

        builder.Services.AddScoped<IPlatformService, PlatformService>();
        builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();


    }
}
