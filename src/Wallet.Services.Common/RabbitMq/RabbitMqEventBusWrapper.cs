using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RawRabbit;
using RawRabbit.Pipe.Middleware;
using Wallet.Commands;
using Wallet.Events;

namespace Wallet.Services.RabbitMq
{
   public class RabbitMqEventBusWrapper:IEventsBus
    {
        private readonly IBusClient _busClient;

        public RabbitMqEventBusWrapper(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public Task SubscribeToEventAsync<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return _busClient.SubscribeAsync<TEvent>(msg => handler.Handle(msg),
                context => context.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TEvent>())));
        }

        public Task PublicEventAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public Task SubscribeToCommandAsync<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return _busClient.SubscribeAsync<TCommand>(msg => handler.Handle(msg),
                context => context.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TCommand>())));
        }

        public Task PublicCommandAsync<TCommand>(TCommand Command) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
        public static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}
