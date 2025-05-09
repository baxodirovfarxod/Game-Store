using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Dal.Configurations.Seeds
{
    public class GenreSeedConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var strategyId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var rpgId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var sportsId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var actionId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
            var adventureId = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
            var puzzleId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

            builder.HasData(
                new Genre { Id = strategyId, Name = "Strategy", ParentGenreId = null },
                new Genre { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "RTS", ParentGenreId = strategyId },
                new Genre { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "TBS", ParentGenreId = strategyId },

                new Genre { Id = rpgId, Name = "RPG", ParentGenreId = null },

                new Genre { Id = sportsId, Name = "Sports", ParentGenreId = null  },
                new Genre { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Races", ParentGenreId = sportsId },
                new Genre { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Rally", ParentGenreId = sportsId },
                new Genre { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Formula", ParentGenreId = sportsId },
                new Genre { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Off-road", ParentGenreId = sportsId },

                new Genre { Id = actionId, Name = "Action", ParentGenreId = null },
                new Genre { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "FPS", ParentGenreId = actionId },
                new Genre { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "TPS", ParentGenreId = actionId },

                new Genre { Id = adventureId, Name = "Adventure", ParentGenreId = null },

                new Genre { Id = puzzleId, Name = "Puzzle & Skill", ParentGenreId = null }
            );
        }
    }
}
