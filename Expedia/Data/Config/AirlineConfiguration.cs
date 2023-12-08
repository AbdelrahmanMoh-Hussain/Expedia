using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.ToTable(nameof(Airline) + "s");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Country)
                .HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Active)
                .HasColumnType("BIT").IsRequired().HasDefaultValue(1);

            builder.HasMany(x => x.Flights)
                .WithOne(x => x.Airline)
                .HasForeignKey(x => x.AirlineId)
                .IsRequired();
        }
    }
}
