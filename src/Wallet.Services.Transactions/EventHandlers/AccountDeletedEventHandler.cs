using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Events;
using Wallet.Services.Events;
using Wallet.Services.Transactions.Domain.Repositories;

namespace Wallet.Services.Transactions.EventHandlers
{
    public class AccountDeletedEventHandler:IEventHandler<AccountDeletedEvent>
    {
        private readonly ITransactionRepository _transactionRepository;

        public AccountDeletedEventHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task Handle(AccountDeletedEvent @event)
        {
            await _transactionRepository.DeleteAccountTransactions(@event.AccountId);
        }
    }
}
