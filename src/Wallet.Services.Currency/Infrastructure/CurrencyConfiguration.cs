using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Services.Currency.Infrastructure
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency.Domain.Models.Currency>
    {
        public void Configure(EntityTypeBuilder<Currency.Domain.Models.Currency> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired();
            builder.Property(e => e.Code)
                .IsRequired();
            builder.Property(e => e.Symbol);
        }
    }
}