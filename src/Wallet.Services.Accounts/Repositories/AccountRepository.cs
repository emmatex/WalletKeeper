using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Accounts.Domain;
using Wallet.Services.Accounts.Domain.Models;
using Wallet.Services.Accounts.Infrastructure;
using Wallet.Services.Events;

namespace Wallet.Services.Accounts.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountsDbContext _context;
        private readonly IEventsBus _eventsBus;

        public AccountRepository(AccountsDbContext context,IEventsBus eventsBus)
        {
            _context = context;
            _eventsBus = eventsBus;
        }
        public Task<IEnumerable<AccountType>> GetAccountTypesAsync()
        {
            return _context.AccountTypes.ToIEnumerableAsync();
        }


        public Task<Account> GetAccountAsync(int id)
        {
            return _context.Account.Include(e => e.AccountType).FirstAsync(e=>e.Id == id);
        }

        public async Task<Account> CreateAccount(Account account)
        {
            var res = await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public Task<IEnumerable<Account>> GetAccountsByUserAsync(Guid userId)
        {
            return _context.Account.Where(e => e.UserId == userId).Include(e => e.AccountType).ToIEnumerableAsync();
        }

        public async Task UpdateAccount(Account account)
        {
            var dbAccount = await _context.Account.FirstAsync(e => e.Id == account.Id);
            dbAccount.Title = account.Title;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(Account account)
        {
            var dbAccount = await _context.Account.FirstAsync(e => e.Id == account.Id);
            _context.Remove(dbAccount);
            await _context.SaveChangesAsync();
            await _eventsBus.PublicEventAsync(new AccountDeletedEvent {AccountId = account.Id});
        }
    }
}
