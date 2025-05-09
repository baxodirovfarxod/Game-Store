using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
      : base(options)
    {
    }

    public DbSet<GamePlatform> GamePlatforms { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GameGenre> GameGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
    }
}
