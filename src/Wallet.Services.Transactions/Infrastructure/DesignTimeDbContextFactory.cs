using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wallet.Services.Transactions.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TransactionsDbContext>
    {
        public TransactionsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TransactionsDbContext>();
            var connectionString = configuration["sql:localConnection"];
            builder.UseSqlServer(connectionString);
            return new TransactionsDbContext(builder.Options);
        }
    }
}
