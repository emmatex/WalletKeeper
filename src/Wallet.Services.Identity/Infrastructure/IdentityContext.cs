using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coddee.Crypto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Identity.Domain.Models;

namespace Wallet.Services.Identity.Infrastructure
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public void Seed()
        {
            if (!Users.Any())
            {
                var pass = PasswordHelper.GenerateHashedPassword("123");
                Users.Add(new User
                {
                    Username = "admin",
                    Email = "admin@mail.com",
                    PasswordHash = pass.Password,
                    PasswordSalt = pass.Salt
                });
                SaveChanges();
            }
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.Username)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .IsRequired();

        }
    }
}
