using Expedia.Entities;
using Expedia.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room) + "s");


            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Capicity)
                .HasColumnType("int").IsRequired();

            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), x => (RoomType)Enum.Parse(typeof(RoomType), x))
                .HasMaxLength(120).IsRequired();
        }
    }
}
