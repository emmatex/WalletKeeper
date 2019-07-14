using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Services.Identity.Domain.Models;
using Wallet.Services.Identity.Domain.Repositories;
using Wallet.Services.Identity.Infrastructure;

namespace Wallet.Services.Identity.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IdentityContext _identityContext;

        public UserRepository(IdentityContext identityContext)
        {
            this._identityContext = identityContext;
        }
        public Task<User> GetUserByUsername(string username)
        {
            return _identityContext.Users.FirstOrDefaultAsync(e => e.Username == username.ToLower());
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _identityContext.Users.FirstOrDefaultAsync(e => e.Email == email.ToLower());
        }

        public async Task<User> InsertItem(User user)
        {
            var res = await this._identityContext.Users.AddAsync(user);
            await _identityContext.SaveChangesAsync();
            return res.Entity;
        }
    }
}
