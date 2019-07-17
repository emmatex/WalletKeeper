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


            var user = new User
            {
                Username = args.Username.ToLower(),
                Email = args.Email.ToLower()
            };

            var res = await _userRepository.InsertItem(user,args.Password);
            return res.Id;
        }

        public async Task<AuthenticationResponse> AuthenticateUser(AuthenticationRequest authenticationRequest)
        {
            var res = new AuthenticationResponse();

            var user = await _userRepository.GetUserByUsername(authenticationRequest.Username.ToLower()) ?? await _userRepository.GetUserByEmail(authenticationRequest.Username.ToLower());

            if (user != null)
            {
                if (await _userRepository.ValidatePassword(user, authenticationRequest.Password))
                {
                    res.IsSuccessful = true;
                    res.UserId = user.Id;
                    res.Username = user.Username;
                    return res;
                }
            }

            res.IsSuccessful = false;
            res.Message = "Invalid Credentials.";
            return res;
        }
    }
}
