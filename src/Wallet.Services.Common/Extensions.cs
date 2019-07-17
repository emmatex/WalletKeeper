using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wallet.Services
{
    public static class Extensions
    {
        
        public static void AddAllowCors(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy("allow", e =>
                {
                    e.SetIsOriginAllowed((host) => true);
                    e.AllowAnyHeader();
                    e.AllowAnyMethod();
                    e.AllowCredentials();
                });
            });
        }

        public static void UseAllowCors(this IApplicationBuilder app)
        {
            app.UseCors("allow");
        }

        public static async Task<IEnumerable<T>> ToIEnumerableAsync<T>(this DbSet<T> dbSet) where T : class
        {
            return (await dbSet.ToListAsync()).AsEnumerable();
        }

        public static async Task<IEnumerable<T>> ToIEnumerableAsync<T>(this IQueryable<T> dbSet) where T : class
            {
                return (await dbSet.ToListAsync()).AsEnumerable();
            }
        }
}
