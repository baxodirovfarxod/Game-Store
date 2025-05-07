using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
      : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
    }
}
