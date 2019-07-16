using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Accounts.Domain;
using Wallet.Services.Accounts.Domain.Models;
using Wallet.Services.Accounts.Infrastructure;

namespace Wallet.Services.Accounts.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly AccountsDbContext _context;

        public AccountRepository(AccountsDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<AccountType>> GetAccountTypesAsync()
        {
            return _context.AccountTypes.ToIEnumerableAsync();
        }

        public Task<Account> InsertItemAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
