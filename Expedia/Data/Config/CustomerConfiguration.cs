using Expedia.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer) + "s");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();


            builder.Property(x => x.Name)
                .HasColumnType("nvarchar").HasMaxLength(120).IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Password)
                .HasColumnType("nvarchar").HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.BankCards)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired(false);
        }
    }
}
