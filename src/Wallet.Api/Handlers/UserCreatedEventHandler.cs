using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Events;

namespace Wallet.Api.Handlers
{
    public class UserCreatedEventHandler:IEventHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent @event)
        {
            Console.WriteLine("User created");
            return Task.CompletedTask;
        }
    }
}
