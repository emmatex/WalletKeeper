using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Services.Accounts.Domain.Models;

namespace Wallet.Services.Accounts.Infrastructure
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountTypeConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
        }

        public void Seed(bool isDevelopment)
        {
            if (!AccountTypes.Any())
            {
                AccountTypes.AddRange(new []
                {
                    new AccountType{ Title = "Cash"}, 
                    new AccountType{ Title = "Card"}, 
                    new AccountType{ Title = "Savings"}, 
                    new AccountType{ Title = "Other"}, 
                });
                SaveChanges();
            }

            if (isDevelopment)
            {
                if (!Account.Any())
                {
                    Account.AddRange(new Account[]
                    {
                        new Account
                        {
                            Title = "Cash default",
                            AccountTypeId = 1,
                            CreatedAt = DateTime.UtcNow,
                            CurrencyCode = "USD",
                            CurrencyId = 1,
                            CurrencySymbol = "$",
                            CurrencyTitle = "US Dollar",
                            UserId = 1
                        }
                    });
                    SaveChanges();
                }
            }
        }
    }

    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.Property(e => e.Title)
                .IsRequired();

            builder.HasKey(e => e.Id);
        }
    }
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseSqlServerIdentityColumn();

            builder.Property(e => e.Title)
                .IsRequired();
            builder.Property(e => e.AccountTypeId)
                .IsRequired();
            builder.Property(e => e.UserId)
                .IsRequired();
            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.HasOne(e => e.AccountType)
                .WithMany()
                .HasForeignKey(e => e.AccountTypeId);

        }
    }
}
