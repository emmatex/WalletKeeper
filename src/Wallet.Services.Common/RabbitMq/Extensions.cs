using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;
using Wallet.Commands;
using Wallet.Events;

namespace Wallet.Services.RabbitMq
{
    public static class Extensions
    {
        public static IEventBusSubscriber AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RawRabbitConfiguration();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            var eventsBus = new RabbitMqEventBusWrapper(client);
            services.AddSingleton<IBusClient>(_ => client);
            services.AddSingleton<IEventsBus>(_ => eventsBus);
            var provider = services.BuildServiceProvider();
            return new EventBusSubscriber(eventsBus,provider);
        }
    }
}
