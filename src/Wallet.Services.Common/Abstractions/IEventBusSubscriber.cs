using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Commands;
using Wallet.Events;

namespace Wallet.Services
{

    public interface IEventBusSubscriber
    {
        IEventBusSubscriber SubscribeToCommandAsync<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        IEventBusSubscriber SubscribeToCommandAsync<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>;
        IEventBusSubscriber SubscribeToCommandAsync<TCommand>() where TCommand : ICommand;
        IEventBusSubscriber SubscribeToEventAsync<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
        IEventBusSubscriber SubscribeToEventAsync<TEvent, THandler>() where TEvent : IEvent where THandler : IEventHandler<TEvent>;
        IEventBusSubscriber SubscribeToEventAsync<TEvent>() where TEvent : IEvent;
    }

    public class EventBusSubscriber: IEventBusSubscriber
    {
        private readonly IEventsBus _bus;
        private readonly IServiceProvider _provider;

        public EventBusSubscriber(IEventsBus bus, IServiceProvider provider)
        {
            _bus = bus;
            _provider = provider;
        }
        
        public IEventBusSubscriber SubscribeToCommandAsync<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _bus.SubscribeToCommandAsync<TCommand>(handler);
            return this;
        }
        public IEventBusSubscriber SubscribeToCommandAsync<TCommand, THandler>() where TCommand : ICommand where THandler : ICommandHandler<TCommand>
        {
            var handler = _provider.GetService<THandler>();
            return SubscribeToCommandAsync(handler);
        }
        public IEventBusSubscriber SubscribeToCommandAsync<TCommand>() where TCommand : ICommand
        {
            return SubscribeToCommandAsync<TCommand, ICommandHandler<TCommand>>();
        }


        public IEventBusSubscriber SubscribeToEventAsync<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            _bus.SubscribeToEventAsync<TEvent>(handler);
            return this;
        }
        public IEventBusSubscriber SubscribeToEventAsync<TEvent, THandler>() where TEvent : IEvent where THandler : IEventHandler<TEvent>
        {
            var handler = _provider.GetService<THandler>();
            return SubscribeToEventAsync(handler);
        }
        public IEventBusSubscriber SubscribeToEventAsync<TEvent>() where TEvent : IEvent
        {
            return SubscribeToEventAsync<TEvent, IEventHandler<TEvent>>();
        }
    }

}
