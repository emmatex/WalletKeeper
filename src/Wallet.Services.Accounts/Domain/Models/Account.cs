using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Accounts.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AccountTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountType AccountType { get; set; }

        public int CurrencyId { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
