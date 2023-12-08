using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class FlightReservationConfiguration : IEntityTypeConfiguration<FlightReservation>
    {
        public void Configure(EntityTypeBuilder<FlightReservation> builder)
        {
            builder.Property(x => x.FromCity)
                 .HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.Property(x => x.ToCity)
                 .HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Flight)
                .WithOne(x => x.FlightReservation)
                .HasForeignKey<FlightReservation>(x => x.FlightId)
                .IsRequired();
        }
    }
}
