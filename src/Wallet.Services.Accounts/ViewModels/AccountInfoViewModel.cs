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
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AccountTypeTitle { get; set; }
        public int AccountTypeId { get; set; }
    }
}
