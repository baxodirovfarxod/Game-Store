﻿using GameStore.Dal;
using Microsoft.EntityFrameworkCore;


namespace GameStore.Api.Configurations;

public static class DatabaseConfigurations
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<MainContext>(options =>
              options.UseSqlServer(connectionString));
    }
}
