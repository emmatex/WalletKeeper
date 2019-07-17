using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Accounts.ViewModels
{
    public class AccountInfoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AccountTypeTitle { get; set; }
        public int AccountTypeId { get; set; }
    }
}
