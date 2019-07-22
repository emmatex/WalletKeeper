using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Transactions.Dto
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public string Notes { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencyCode { get; set; }
        public int TransactionCategoryId { get; set; }
        public List<string> Tags { get; set; }
    }
}
