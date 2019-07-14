using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Wallet.Services.Identity.Domain.Models;
using Wallet.Services.Identity.Services;

namespace Wallet.Services.Identity.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController:Controller
    {
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            var res = await _userService.AuthenticateUser(authenticationRequest);
            if (res.IsSuccessful)
            {
                var expires = DateTime.Today.AddMonths(1);
                var token = CreateToken(new Claim[] { }, expires);

                return Ok(new ClientAuthenticationResponse
                {
                    IsSuccessful = true,
                    Expires = expires,
                    Token = token
                });
            }

            return Unauthorized(new ClientAuthenticationResponse{
                Message=res.Message
            });
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expires)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Tokens:Issuer"],
                    _configuration["Tokens:Audience"],
                    claims,
                    expires: expires,
                    signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
