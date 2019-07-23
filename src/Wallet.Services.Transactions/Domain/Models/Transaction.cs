using System;
using System.Collections.Generic;

namespace Wallet.Services.Transactions.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
        public string AccountTitle { get; set; }
        public Guid UserId { get; set; }
        public string Notes { get; set; }
        public int? FromAccount { get; set; }
        public int? ToAccount { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencyCode { get; set; }
        public int TransactionCategoryId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public List<TransactionTag> TransactionTags { get; set; }
    }
}
