using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wallet.Commands;
using Wallet.Events;

namespace Wallet.Services
{
    public interface IEventsBus
    {
        Task SubscribeToEventAsync<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
        Task PublicEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;

        Task SubscribeToCommandAsync<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;
        Task PublicCommandAsync<TCommand>(TCommand Command) where TCommand : ICommand;
    }
}
