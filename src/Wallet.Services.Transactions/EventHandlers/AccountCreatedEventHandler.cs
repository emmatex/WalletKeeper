using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Events;
using Wallet.Services.Events;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Domain.Repositories;

namespace Wallet.Services.Transactions.EventHandlers
{
    public class AccountCreatedEventHandler:IEventHandler<AccountCreatedEvent>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCreatedEventHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(AccountCreatedEvent @event)
        {
            await _accountRepository.AddAccount(new Account
            {
                AccountId = @event.AccountId,
                Title = @event.AccountTitle
            });
        }
    }
}
