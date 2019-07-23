using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Dto;
using Wallet.Services.Transactions.ViewModels;

namespace Wallet.Services.Transactions.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionCategory>> GetTransactionCategoriesAsync(Guid userId, int typeId);
        Task<IEnumerable<AccountTransactionViewModel>> GetAccountTransactions(int accountId);
        Task<IEnumerable<AccountTransactionViewModel>> GetUserTransactions(Guid userId);
        Task<AccountTransactionViewModel> CreateTransaction(Transaction transaction);
        Task<TransactionCategory> CreateCategory(TransactionCategory category);
        Task<AccountTransactionViewModel> GetTransaction(Guid id);
        Task DeleteAccountTransactions(int accountId);
        Task<decimal> GetTransactionsSumByType(int transactionType, int days, Guid userId);
    }
}
