using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Identity.Domain.Repositories;
using Wallet.Services.Identity.Repositories;

namespace Wallet.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IdentityContext>();
            context.Database.Migrate();
            context.Seed();
        }
        public static void AddSqlRepos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(config => { config.UseSqlServer(configuration["sql:connection"]); });
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
