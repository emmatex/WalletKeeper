using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Wallet.Services.Authentication;
using Wallet.Services.Identity.Domain.Models;
using Wallet.Services.Identity.Dto;

namespace Wallet.Services.Identity.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        public AuthController(
            IConfiguration configuration,
            UserManager<WalletUser> userManager)
        {
            
            _configuration = configuration;
            _userManager = userManager;

            _jwtConfigurations = new JwtOptions();
            var section = configuration.GetSection("jwt");
            section.Bind(_jwtConfigurations);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfigurations.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(creds);
        }

        private readonly JwtHeader _jwtHeader;
        private readonly JwtOptions _jwtConfigurations;
        //private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<WalletUser> _userManager;

        [HttpPost]
        [Route("createUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUser)
        {
            var res = await _userManager.CreateAsync(new WalletUser
            {
                Email = createUser.Email,
                UserName = createUser.UserName
            }, createUser.Password);

            if (res.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        //[HttpPost]
        //[Route("authenticate")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        //{
        //    var res = await _userService.AuthenticateUser(authenticationRequest);
        //    if (res.IsSuccessful)
        //    {
        //        var token = CreateToken(res.UserId, res.Username);

        //        return Ok(new ClientAuthenticationResponse
        //        {
        //            IsSuccessful = true,
        //            Token = token
        //        });
        //    }

        //    return Unauthorized(new ClientAuthenticationResponse
        //    {
        //        Message = res.Message
        //    });
        //}

        private string CreateToken(int userId, string username)
        {
            try
            {

                var nowUtc = DateTime.UtcNow;
                var expires = nowUtc.AddMonths(1);
                var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
                var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
                var now = (long)(new TimeSpan(DateTime.UtcNow.Ticks - centuryBegin.Ticks).TotalSeconds);

                var payload = new JwtPayload
                {
                    {"sub",userId },
                    {"iss",_jwtConfigurations.Issuer},
                    {"aud",_jwtConfigurations.Audience},
                    {"iat",now},
                    {"exp",exp},
                    {"unique_name",userId},
                };


                var token = new JwtSecurityToken(_jwtHeader, payload);
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
