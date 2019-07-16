using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wallet.Services.Accounts.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AccountsDbContext>
    {
        public AccountsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AccountsDbContext>();
            var connectionString = configuration["sql:localConnection"];
            builder.UseSqlServer(connectionString);
            return new AccountsDbContext(builder.Options);
        }
    }
}
