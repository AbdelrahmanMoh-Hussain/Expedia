using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable(nameof(Flight) + "s");

            builder.ToTable(t => t.HasCheckConstraint("CK_NumberOfSeatsGreaterThanZeroAndLessThan1000", "NumberOfSeats >= 0 AND NumberOfSeats <= 1000"));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();


            builder.Property(x => x.AirplaneName)
                .HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();

            builder.Property(x => x.NumberOfSeats)
                .HasColumnType("INT").IsRequired();
        }
    }
}
