using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coddee.Loggers;
using Wallet.Events;

namespace Wallet.Api.Handlers
{
    public class UserCreatedEventHandler:IEventHandler<UserCreatedEvent>
    {
        private readonly ILogger _logger;

        public UserCreatedEventHandler(ILogger logger)
        {
            _logger = logger;
        }
        public Task Handle(UserCreatedEvent @event)
        {
            _logger.Log(nameof(UserCreatedEventHandler),$"User created {@event.Id} | {@event.Username} | {@event.Email}");
            return Task.CompletedTask;
        }
    }
}
