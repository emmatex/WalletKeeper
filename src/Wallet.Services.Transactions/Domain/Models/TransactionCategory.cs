using System;

namespace Wallet.Services.Transactions.Domain.Models
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid? UserId { get; set; }
        public int TransactionType { get; set; }
    }
}
