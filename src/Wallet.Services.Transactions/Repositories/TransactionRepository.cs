using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Domain.Repositories;
using Wallet.Services.Transactions.Infrastructure;
using Wallet.Services.Transactions.ViewModels;

namespace Wallet.Services.Transactions.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionsDbContext _context;

        public TransactionRepository(TransactionsDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TransactionCategory>> GetTransactionCategoriesAsync(int userId)
        {
            return _context.TransactionCategories
                .Where(e => !e.UserId.HasValue || e.UserId == userId)
                .ToIEnumerableAsync();
        }

        public Task<IEnumerable<AccountTransactionViewModel>> GetAccountTransactions(int accountId)
        {
            return _context.Transactions.Where(e => e.AccountId == accountId)
                .Include(e => e.TransactionCategory)
                .Include(e => e.TransactionTags)
                .OrderByDescending(e=>e.Date)
                .Select(e => MapToViewModel(e)).ToIEnumerableAsync();
        }

        public Task<IEnumerable<AccountTransactionViewModel>> GetUserTransactions(int userId)
        {
            return _context.Transactions.Where(e => e.UserId == userId)
                .Include(e => e.TransactionCategory)
                .Include(e => e.TransactionTags)
                .OrderByDescending(e => e.Date)
                .Select(e => MapToViewModel(e)).ToIEnumerableAsync();
        }

        public async Task<AccountTransactionViewModel> CreateTransaction(Transaction transaction)
        {
            var res = _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return MapToViewModel(res.Entity);
        }

        public async Task<TransactionCategory> CreateCategory(TransactionCategory category)
        {
            var res = _context.TransactionCategories.Add(category);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<AccountTransactionViewModel> GetTransaction(Guid id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(e => e.Id == id);
            if (transaction is null)
                return null;
            return MapToViewModel(transaction);
        }

        public async Task DeleteAccountTransactions(int accountId)
        {
            _context.Transactions.RemoveRange(_context.Transactions.Where(e=>e.AccountId == accountId));
            await _context.SaveChangesAsync();
        }

        private AccountTransactionViewModel MapToViewModel(Transaction e)
        {
            return new AccountTransactionViewModel
            {
                Id = e.Id,
                TransactionTypeId = e.TypeId,
                Notes = e.Notes,
                Date = e.Date,
                Amount = e.Amount,
                TransactionCategoryId = e.TransactionCategoryId,
                TransactionCategoryTitle = e.TransactionCategory.Title,
                Tags = e.TransactionTags.Select(t => t.Tag).ToList(),
                AccountId = e.AccountId,
                CurrencyTitle = e.CurrencyTitle,
                CurrencyId = e.CurrencyId,
                CurrencyCode = e.CurrencyCode,
                AccountTitle = e.AccountTitle
            };
        }
    }
}
