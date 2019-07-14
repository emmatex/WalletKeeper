using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coddee.Crypto;
using Wallet.Services.Identity.Domain.Models;
using Wallet.Services.Identity.Domain.Repositories;

namespace Wallet.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUser(CreateUserArgs args)
        {
            if (string.IsNullOrEmpty(args.Username))
                throw new ArgumentException("username field is required.", nameof(CreateUserArgs.Username));
            if (string.IsNullOrEmpty(args.Email))
                throw new ArgumentException("email field is required.", nameof(CreateUserArgs.Email));
            if (string.IsNullOrEmpty(args.Password))
                throw new ArgumentException("password field is required.", nameof(CreateUserArgs.Password));

            if ((await _userRepository.GetUserByUsername(args.Username)) != null)
                throw new ArgumentException($"the username '{args.Username}' is already in use.");
            if ((await _userRepository.GetUserByEmail(args.Email)) != null)
                throw new ArgumentException($"the email '{args.Email}' is already in use.");


            var pass = PasswordHelper.GenerateHashedPassword(args.Password);
            var user = new User
            {
                Username = args.Username.ToLower(),
                Email = args.Email.ToLower(),
                PasswordHash = pass.Password,
                PasswordSalt = pass.Salt
            };

            var res = await _userRepository.InsertItem(user);
            return res.Id;
        }
    }
}
