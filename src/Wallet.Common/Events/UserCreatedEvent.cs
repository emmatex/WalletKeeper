using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Events
{
    public class UserCreatedEvent:IEvent
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
