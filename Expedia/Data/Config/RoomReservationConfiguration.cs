using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class RoomReservationConfiguration : IEntityTypeConfiguration<RoomReservation>
    {
        public void Configure(EntityTypeBuilder<RoomReservation> builder)
        {
            builder.HasOne(x => x.Room)
                .WithOne(x => x.RoomReservation)
                .HasForeignKey<RoomReservation>(x => x.RoomId)
                .IsRequired();
        }
    }
}
