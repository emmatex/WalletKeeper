using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Identity.Services
{
    public interface IUserService
    {
        Task<int> CreateUser(CreateUserArgs args);
    }

    public class CreateUserArgs
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
