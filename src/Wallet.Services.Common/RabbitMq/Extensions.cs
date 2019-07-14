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
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RawRabbitConfiguration();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(msg => handler.Handle(msg),
                context => context.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TCommand>())));
        }
        public static Task WithCommandHandlerAsync<TCommand, THandler>(this IBusClient bus,IServiceProvider provider) where TCommand : ICommand where THandler: ICommandHandler<TCommand>
        {
            var handler = provider.GetService<THandler>();
            return bus.WithCommandHandlerAsync<TCommand>(handler);
        }

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, IServiceProvider provider) where TCommand : ICommand 
        {
            var handler = provider.GetService<ICommandHandler<TCommand>>();
            return bus.WithCommandHandlerAsync<TCommand>(handler);
        }


        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return bus.SubscribeAsync<TEvent>(msg => handler.Handle(msg),
                context => context.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TEvent>())));
        }
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IServiceProvider provider) where TEvent : IEvent 
        {
            var handler = provider.GetService<IEventHandler<TEvent>>();
            return bus.WithEventHandlerAsync<TEvent>(handler);
        }

        public static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}
