using Microsoft.EntityFrameworkCore;

namespace GameStore.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options)
      : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
    }
}
