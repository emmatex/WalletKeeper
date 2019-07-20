using System;
using Coddee.AspNet;
using Coddee.Loggers;
using Coddee.Windows.AppBuilder;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Wallet.Api.Handlers;
using Wallet.Events;
using Wallet.Services.Authentication;
using Wallet.Services.RabbitMq;

namespace Wallet.Api
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

            services.AddHealthChecksUI();
                


            services.AddContainer();
            services.AddLogger(new LoggerOptions(LoggerTypes.DebugOutput, LogRecordTypes.Debug));
            services.AddJwtAuthentication(_configuration);
            services.AddScoped<IEventHandler<UserCreatedEvent>, UserCreatedEventHandler>();
            services.AddRabbitMq(_configuration).SubscribeToEventAsync<UserCreatedEvent>();
            services.AddMvc();
            services.AddOcelot(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");
            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });

            app.UseMvcWithDefaultRoute();
            app.UseOcelot().Wait();
        }
    }
}
