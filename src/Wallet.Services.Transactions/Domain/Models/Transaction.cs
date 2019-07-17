using System;

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
        public string Notes { get; set; }
        public int? FromAccount { get; set; }
        public int? ToAccount { get; set; }
    }
}
