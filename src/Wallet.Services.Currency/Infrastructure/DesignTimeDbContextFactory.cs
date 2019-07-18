using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wallet.Services.Currency.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CurrenciesDbContext>
    {
        public CurrenciesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CurrenciesDbContext>();
            var connectionString = configuration["sql:localConnection"];
            builder.UseSqlServer(connectionString);
            return new CurrenciesDbContext(builder.Options);
        }
    }
}
