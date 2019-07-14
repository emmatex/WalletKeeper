using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coddee.Crypto;
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

        public async Task<User> InsertItem(User user, string password)
        {
            var pass = PasswordHelper.GenerateHashedPassword(password);
            user.PasswordHash = pass.Password;
            user.PasswordSalt = pass.Salt;
            var res = await this._identityContext.Users.AddAsync(user);
            await _identityContext.SaveChangesAsync();
            return res.Entity;
        }

        public Task<bool> ValidatePassword(User user, string password)
        {
            return Task.FromResult(PasswordHelper.ValidatePassword(password, user.PasswordSalt, user.PasswordHash));
        }
    }
}
