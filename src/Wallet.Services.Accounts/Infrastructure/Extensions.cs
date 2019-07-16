using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Accounts.Domain;
using Wallet.Services.Accounts.Repositories;

namespace Wallet.Services.Accounts.Infrastructure
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<AccountsDbContext>();
            context.Database.Migrate();
            context.Seed();
        }

        public static void AddSqlRepos(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AccountsDbContext>(config => { config.UseSqlServer(configuration["sql:connection"]); });
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
