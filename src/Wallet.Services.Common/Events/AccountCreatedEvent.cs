using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Events;

namespace Wallet.Services.Events
{
    public class AccountCreatedEvent : IEvent
    {
        public int AccountId { get; set; }
        public string AccountTitle { get; set; }
    }
}
