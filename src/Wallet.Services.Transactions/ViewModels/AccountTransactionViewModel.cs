using System;
using System.Collections.Generic;
using Wallet.Services.Transactions.Domain.Models;

namespace Wallet.Services.Transactions.ViewModels
{
    public class AccountTransactionViewModel
    {
        public Guid Id { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionTypeTitle => ((TransactionTypes) TransactionTypeId).ToString();

        public int AccountId { get; set; }
        public string AccountTitle { get; set; }


        public int TransactionCategoryId { get; set; }
        public string TransactionCategoryTitle { get; set; }

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public List<string> Tags { get; set; }

        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencyCode { get; set; }
    }
}
