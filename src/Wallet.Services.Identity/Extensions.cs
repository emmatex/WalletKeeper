using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Services.Identity.Infrastructure;

namespace Wallet.Services.Identity
{
    public static class Extensions
    {
        public static void EnsureDataSeed(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IdentityContext>();
            context.Database.Migrate();
            context.Seed();
        }
    }
}
