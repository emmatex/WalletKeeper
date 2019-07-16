using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wallet.Services.Accounts.Domain;
using Wallet.Services.Accounts.Domain.Models;

namespace Wallet.Services.Accounts.Controllers
{
    [Route("/api/v1/[controller]")]
    public class AccountController:Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("getTypes")]
        [ProducesResponseType(typeof(IEnumerable<AccountType>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await _accountRepository.GetAccountTypesAsync());
        }
    }
}
