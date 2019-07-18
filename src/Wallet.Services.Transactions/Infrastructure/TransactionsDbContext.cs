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
            builder.HasKey(e => e.Id);

            builder.Property(e => e.AccountId)
                .IsRequired();
            builder.Property(e => e.Amount)
                .IsRequired();
            builder.Property(e => e.Date)
                .IsRequired();
            builder.Property(e => e.Type)
                .IsRequired();
            builder.Property(e => e.TypeId)
                .IsRequired();
            builder.Property(e => e.FromAccount);
            builder.Property(e => e.ToAccount);
            builder.Property(e => e.Notes);
        }
    }
}