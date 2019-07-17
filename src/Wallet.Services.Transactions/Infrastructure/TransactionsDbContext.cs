using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Services.Transactions.Domain.Models;

namespace Wallet.Services.Transactions.Infrastructure
{
    public class TransactionsDbContext:DbContext
    {
        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TransactionConfiguration());
        }

        public void Seed()
        {
           
        }
    }

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(e => e.Title)
                .IsRequired();

            builder.HasKey(e => e.Id);
        }
    }
}
}
