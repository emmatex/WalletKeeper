using System;

namespace Wallet.Services.Transactions.Domain.Models
{
    public class TransactionTag
    {
        public Guid TransactionId { get; set; }
        public string Tag { get; set; }
    }
}
