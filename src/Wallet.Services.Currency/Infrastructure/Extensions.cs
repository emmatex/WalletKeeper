using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Currency.Domain.Repositories;
using Wallet.Services.Currency.Repositories;

namespace Wallet.Services.Currency.Infrastructure
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<CurrenciesDbContext>();
            context.Database.Migrate();
            context.Seed();
        }

        public static void AddSqlRepos(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CurrenciesDbContext>(config => { config.UseSqlServer(configuration["sql:connection"]); });
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        }
    }
}
