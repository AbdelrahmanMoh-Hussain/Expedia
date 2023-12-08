using Expedia.Entities;
using Expedia.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedia.Data.Config
{
    public class BankCardConfiguration : IEntityTypeConfiguration<BankCard>
    {
        public void Configure(EntityTypeBuilder<BankCard> builder)
        {
            builder.ToTable(nameof(BankCard) + "s");

            builder.HasKey(x => new { x.CardNumber, x.Company });

            builder.Property(x => x.CardNumber)
                .HasColumnType("nvarchar").HasMaxLength(15);

            builder.Property(x => x.Company)
                .HasColumnType("nvarchar").HasMaxLength(120);

            builder.Property(x => x.ExpireDate)
                .HasColumnType("datetime2").HasPrecision(2).IsRequired();

            builder.Property(x => x.Balance)
                .HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(x => x.Type)
                .HasConversion(x => x.ToString(), x => (BankCardType)Enum.Parse(typeof(BankCardType), x))
                .HasMaxLength(120).IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.BankCards)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
