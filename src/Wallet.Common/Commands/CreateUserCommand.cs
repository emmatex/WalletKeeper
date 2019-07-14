using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Commands
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand()
        {
            
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
