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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable(nameof(Reservation) + "s");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Cost)
                .HasColumnType("decimal").HasPrecision(18,2).IsRequired();


            builder.OwnsOne(
                    x => x.Period,
                    p => {
                        p.Property(x => x.StartDate)
                            .HasColumnType("datetime2").HasColumnName("StartDate").HasPrecision(2).IsRequired();

                        p.Property(x => x.EndDate)
                            .HasColumnType("datetime2").HasColumnName("EndDate").HasPrecision(2).IsRequired();
                    }
                );


            builder.HasDiscriminator<string>("ReservationType")
                .HasValue<RoomReservation>("Room")
                .HasValue<FlightReservation>("Flight");
        }
    }
}
