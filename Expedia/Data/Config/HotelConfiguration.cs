using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedia.Data.Config
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable(nameof(Hotel) + "s");

            builder.ToTable(t => t.HasCheckConstraint("CK_NumberOfStarsBetweenOneAndFiveStars", "NumberOfStars BETWEEN 1 AND 5"));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar").HasMaxLength(120).IsRequired();

            builder.Property(x => x.Country)
                .HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.Property(x => x.City)
                .HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Rooms)
                .WithOne(x => x.Hotel)
                .HasForeignKey(x => x.HotelId)
                .IsRequired();
        }
    }
}
