using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using Wallet.Commands;
using Wallet.Events;
using Wallet.Services.Identity.Services;

namespace Wallet.Services.Identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IEventsBus _eventBus;

        public CreateUserCommandHandler(IUserService userService,IEventsBus eventBus)
        {
            _userService = userService;
            _eventBus = eventBus;
        }

        public async Task Handle(CreateUserCommand command)
        {
            var id = await _userService.CreateUser(new CreateUserArgs
            {
                Username = command.Username,
                Email = command.Email,
                Password = command.Password
            });

            await _eventBus.PublicEventAsync(new UserCreatedEvent
            {
                Username = command.Username,
                Email = command.Email,
                Id = id
            });
        }
    }
}
