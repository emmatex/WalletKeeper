using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Services.Accounts.Domain.Models;

namespace Wallet.Services.Accounts.ViewModels
{
    public class AccountInfoViewModel
    {
        public AccountInfoViewModel(Account account)
        {
            AccountTypeId = account.AccountTypeId;
            Id = account.Id;
            CreatedAt = account.CreatedAt;
            Title = account.Title;
            AccountTypeTitle = account.AccountType.Title;
            CurrencyId = account.CurrencyId;
            CurrencyTitle = account.CurrencyTitle;
            CurrencySymbol = account.CurrencySymbol;
            CurrencyCode = account.CurrencyCode;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AccountTypeTitle { get; set; }
        public int AccountTypeId { get; set; }

        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyTitle { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
