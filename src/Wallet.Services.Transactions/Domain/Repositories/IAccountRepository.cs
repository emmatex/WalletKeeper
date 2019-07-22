using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Services.Transactions.Domain.Models;

namespace Wallet.Services.Transactions.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task<Account> GetAccountAsync(int id);
    }
}
