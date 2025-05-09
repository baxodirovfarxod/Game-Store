using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Dal.Configurations.Seeds;

public class PlatformSeedConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasData(
            new Platform { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Type = "Mobile" },
            new Platform { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Type = "Browser" },
            new Platform { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Type = "Desktop" },
            new Platform { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Type = "Console" }
        );
    }
}


