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
   public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.Type)
                .IsUnique();

            builder.ToTable("Platforms");   
        }
    }
}
