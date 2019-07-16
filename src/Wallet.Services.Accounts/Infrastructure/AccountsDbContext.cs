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
                    new AccountType{Id = 1 , Title = "Cash"}, 
                    new AccountType{Id = 2 , Title = "Card"}, 
                    new AccountType{Id = 3 , Title = "Savings"}, 
                    new AccountType{Id = 4 , Title = "Other"}, 
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
            builder.Property(e => e.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo();

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
