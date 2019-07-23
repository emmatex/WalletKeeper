using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Wallet.Services.Identity.Infrastructure;

namespace Wallet.Services.Identity
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WalletIdentityDbContext>
    {
        public WalletIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<WalletIdentityDbContext>();
            var connectionString = configuration["sql:localConnection"];
            builder.UseSqlServer(connectionString);
            return new WalletIdentityDbContext(builder.Options);
        }
    }
}
