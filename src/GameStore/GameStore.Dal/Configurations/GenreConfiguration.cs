using GameStore.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Dal.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.Id);
            builder.Property(g=>g.Id)
                .IsRequired();
            builder.Property(g => g.Name)
                  .IsRequired();
            builder.HasIndex(g => g.Name)
                   .IsUnique();

            builder.Property(g => g.ParentGenreId)
                   .IsRequired(false);

            builder.HasOne(g => g.ParentGenre)
                   .WithMany(g => g.SubGenres)
                   .HasForeignKey(g => g.ParentGenreId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
