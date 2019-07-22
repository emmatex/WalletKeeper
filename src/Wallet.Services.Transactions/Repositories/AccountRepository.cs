using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Domain.Repositories;
using Wallet.Services.Transactions.Infrastructure;

namespace Wallet.Services.Transactions.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TransactionsDbContext _context;

        public AccountRepository(TransactionsDbContext context)
        {
            _context = context;
        }

        public async Task AddAccount(Account account)
        {
            await _context.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(e => e.AccountId == id);
        }
    }
}
