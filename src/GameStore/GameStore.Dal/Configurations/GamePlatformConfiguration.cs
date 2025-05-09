using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Dal.Configurations
{
    public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatform>
    {
        public void Configure(EntityTypeBuilder<GamePlatform> builder)
        {
            builder.HasKey(gp => new { gp.GameId, gp.PlatformId });

            builder.HasOne(gp => gp.Game)
                   .WithMany(g => g.GamePlatforms)
                   .HasForeignKey(gp => gp.GameId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gp => gp.Platform)
                   .WithMany(p => p.GamePlatforms)
                   .HasForeignKey(gp => gp.PlatformId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(gp => new { gp.GameId, gp.PlatformId })
                   .IsUnique();
        }
    }
}
