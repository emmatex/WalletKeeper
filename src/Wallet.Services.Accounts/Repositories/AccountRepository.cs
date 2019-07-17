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
    public class AccountRepository : IAccountRepository
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

        public Task<Account> GetAccountAsync(int id)
        {
            return _context.FindAsync<Account>(id);
        }

        public async Task<Account> CreateAccount(Account account)
        {
            var res = await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public Task<IEnumerable<Account>> GetAccountsByUserAsync(int userId)
        {
            return _context.Account.Where(e => e.UserId == userId).Include(e => e.AccountType).ToIEnumerableAsync();
        }
    }
}
