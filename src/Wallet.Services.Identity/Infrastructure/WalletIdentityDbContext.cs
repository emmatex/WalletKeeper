using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Identity.Domain.Models;

namespace Wallet.Services.Identity.Infrastructure
{
    public class WalletIdentityDbContext : IdentityDbContext<WalletUser>
    {
        public WalletIdentityDbContext(DbContextOptions<WalletIdentityDbContext> options)
            : base(options)
        { }

    }
}
