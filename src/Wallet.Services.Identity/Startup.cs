using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using RawRabbit;
using Wallet.Commands;
using Wallet.Services.Authentication;
using Wallet.Services.Identity.Domain.Repositories;
using Wallet.Services.Identity.Handlers;
using Wallet.Services.Identity.Infrastructure;
using Wallet.Services.Identity.Repositories;
using Wallet.Services.Identity.Services;
using Wallet.Services.RabbitMq;

namespace Wallet.Services.Identity
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddJwtAuthentication(_configuration);
            services.AddSqlRepos(_configuration);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();

            services.AddRabbitMq(_configuration).SubscribeToCommandAsync<CreateUserCommand>();
            services.AddAllowCors();
            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.EnsureDataSeed();
            }
            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
            app.UseAllowCors();
            app.UseMvcWithDefaultRoute();
        }


    }
}
