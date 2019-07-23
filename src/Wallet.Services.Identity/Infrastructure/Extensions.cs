using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Identity.Domain.Models;

namespace Wallet.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;

            serviceProvider.GetService<WalletIdentityDbContext>().Database.Migrate();
            serviceProvider.GetService<ConfigurationDbContext>().Database.Migrate();
            serviceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

            var userManager = serviceProvider.GetService<UserManager<WalletUser>>();
            new WalletIdentityDbContextSeeder(userManager).SeedAsync().Wait();
            //context.Seed();
        }
        public static void AddSqlRepos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WalletIdentityDbContext>(config => { config.UseSqlServer(configuration["sql:connection"]); });
            //services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
