using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Transactions.Domain.Repositories;
using Wallet.Services.Transactions.Repositories;

namespace Wallet.Services.Transactions.Infrastructure
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app,bool isDevelopment)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<TransactionsDbContext>();
            context.Database.Migrate();
            context.Seed(isDevelopment);
        }

        public static void AddSqlRepos(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TransactionsDbContext>(config => { config.UseSqlServer(configuration["sql:connection"]); });
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
