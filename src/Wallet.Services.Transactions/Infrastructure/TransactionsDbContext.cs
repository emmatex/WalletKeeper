using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Services.Transactions.Domain.Models;

namespace Wallet.Services.Transactions.Infrastructure
{
    public class TransactionsDbContext : DbContext
    {
        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionTag> TransactionTags { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TransactionCategoryConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new TransactionTagConfiguration());
        }

        public void Seed(bool isDevelopment)
        {
            if (!TransactionCategories.Any())
            {
                TransactionCategories.AddRange(new[]
                {
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Salary"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Refund"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Investment"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Allowance"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Bonus"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Income,Title = "Other"},

                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Food"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Bill"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Transportation"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Car"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Shopping"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Clothing"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Smoking"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Electronics"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Travel"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Education"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Gifts"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Sports"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Entertainment"},
                    new TransactionCategory{TransactionType = (int)TransactionTypes.Expense,Title = "Other"},
                });
                SaveChanges();
            }

            if (isDevelopment)
            {
                if (!Transactions.Any())
                {
                    Transactions.AddRange(new[]
                    {
                        new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 1,
                            AccountTitle = "Default cash",
                            Amount = 200,
                            Date = DateTime.UtcNow,
                            Notes = "Default transaction",
                            TransactionCategoryId = 1,
                            Type = "Income",
                            TypeId = (int)TransactionTypes.Income,
                            TransactionTags = new List<TransactionTag>{new TransactionTag { Tag = "Default"} },
                            UserId = 1,
                            CurrencyTitle = "US Dollar",
                            CurrencyId = 1,
                            CurrencyCode = "USD",

                        },
                        new Transaction
                        {
                            Id = Guid.NewGuid(),
                            AccountId = 1,
                            AccountTitle = "Default cash",
                            Amount = 75,
                            Date = DateTime.UtcNow,
                            Notes = "Default transaction",
                            TransactionCategoryId = 2,
                            Type = "Expense",
                            TypeId = (int)TransactionTypes.Expense,
                            TransactionTags = new List<TransactionTag>{new TransactionTag { Tag = "Default"} },
                            UserId = 1,
                            CurrencyTitle = "US Dollar",
                            CurrencyId = 1,
                            CurrencyCode = "USD",
                        }
                    });

                    SaveChanges();
                }

                if (!Accounts.Any())
                {
                    Accounts.AddRange(new Account[]
                    {
                        new Account
                        {
                            Title = "Cash default",
                            AccountId = 1,
                            UserId=1
                        }
                    });
                    SaveChanges();
                }
            }
        }
    }

    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.AccountId)
                .IsRequired();

            builder.Property(e => e.AccountTitle)
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


            builder.HasOne(e => e.TransactionCategory)
                .WithMany()
                .HasForeignKey(e => e.TransactionCategoryId);

            builder.HasMany(e => e.TransactionTags)
                .WithOne()
                .HasForeignKey(e => e.TransactionId);
        }
    }

    public class TransactionTagConfiguration : IEntityTypeConfiguration<TransactionTag>
    {
        public void Configure(EntityTypeBuilder<TransactionTag> builder)
        {
            builder.HasKey(e => new { e.TransactionId, e.Tag });
        }
    }
    public class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo();

            builder.Property(e => e.Title)
                .IsRequired();
        }
    }
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.Id).IsRequired().ValueGeneratedNever();
            builder.Property(e => e.AccountId).IsRequired();
            builder.Property(e => e.Title)
                .IsRequired();
            builder.Property(e => e.UserId)
                .IsRequired();
        }
    }
}