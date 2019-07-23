using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Wallet.Services.Identity.Domain.Models;

namespace Wallet.Services.Identity.Infrastructure
{
    public class WalletIdentityDbContextSeeder
    {
        private readonly UserManager<WalletUser> _userManager;

        public WalletIdentityDbContextSeeder(UserManager<WalletUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new WalletUser
                {
                    Email = "Admin@Mail.com",
                    UserName = "admin"
                }, "123");
            }
        }
    }
}
