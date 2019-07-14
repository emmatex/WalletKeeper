using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using Wallet.Api.Handlers;
using Wallet.Events;
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
            services.AddRabbitMq(_configuration);
            services.AddMvc();


            services.AddScoped<IEventHandler<UserCreatedEvent>, UserCreatedEventHandler>();
            ConfigureEventBus(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }

        private void ConfigureEventBus(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var bus = provider.GetService<IBusClient>();
            bus.WithEventHandlerAsync<UserCreatedEvent>(provider);
        }
    }
}
