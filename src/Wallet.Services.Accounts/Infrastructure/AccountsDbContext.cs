using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
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

        public void Seed()
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
