using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TotalAmount).HasPrecision(18, 2);
        builder.Property(t => t.ExchangeRate).HasPrecision(18, 6);

        builder.HasMany(t => t.Items)
               .WithOne(ti => ti.Transaction)
               .HasForeignKey(ti => ti.TransactionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}