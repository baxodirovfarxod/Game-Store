using GameStore.Bll.MappingProfile;
using GameStore.Bll.Services;
using GameStore.Repository.Repositories.GenreRepository;

namespace GameStore.Api.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCaching();
        builder.Services.AddAutoMapper(typeof(GenreProfiles));
        
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
    }
}
