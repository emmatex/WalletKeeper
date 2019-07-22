using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Transactions.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
