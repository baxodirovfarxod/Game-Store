using GameStore.Bll.Services;
using GameStore.Repository.Repositories;

namespace GameStore.Api.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPlatformService, PlatformService>();
        builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
