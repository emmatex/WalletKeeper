using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Services.Identity.Domain.Models;

namespace Wallet.Services.Identity.Services
{
    public interface IUserService
    {
        Task<int> CreateUser(CreateUserArgs args);
        Task<AuthenticationResponse> AuthenticateUser(AuthenticationRequest authenticationRequest);
    }

    public class AuthenticationResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; } = -1;
        public string Username { get; set; }
    }

    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class CreateUserArgs
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
