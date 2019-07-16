using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Services.Accounts.Domain.Models;

namespace Wallet.Services.Accounts.Domain
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountType>> GetAccountTypesAsync();
        Task<Account> InsertItemAsync(Account account);
    }
}
