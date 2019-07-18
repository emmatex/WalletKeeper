using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Services.Accounts.Domain;
using Wallet.Services.Accounts.Domain.Models;
using Wallet.Services.Accounts.ViewModels;
using Wallet.Services.Authentication;

namespace Wallet.Services.Accounts.Controllers
{
    [Route("/api/v1/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IIdentityService _identityService;

        public AccountController(IAccountRepository accountRepository,IIdentityService identityService)
        {
            _accountRepository = accountRepository;
            _identityService = identityService;
        }

        [HttpGet]
        [Route("getTypes")]
        [ProducesResponseType(typeof(IEnumerable<AccountType>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetTypes()
        {
            return Ok(await _accountRepository.GetAccountTypesAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Account), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _accountRepository.GetAccountAsync(id);

            if (account == null)
                return NotFound("No item with this id found.");

            if (account.UserId != _identityService.GetUserId())
                return Unauthorized("The requested account is not owned by the requesting user.");

            return Ok(new AccountInfoViewModel(account));
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            if (account == null)
                return BadRequest("Account parameter not found.");

            account.UserId = _identityService.GetUserId();
            account.CreatedAt = DateTime.UtcNow;

            var res = await _accountRepository.CreateAccount(account);

            var routeValues = new { id = res.Id };
            return CreatedAtAction(nameof(GetAccount), routeValues, routeValues);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateAccount([FromBody] Account account)
        {
            if (account == null)
                return BadRequest("Account parameter not found.");

            if ((await _accountRepository.GetAccountAsync(account.Id)).UserId != _identityService.GetUserId())
                return Unauthorized("This account is owned by a different user.");


            await _accountRepository.UpdateAccount(account);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _accountRepository.GetAccountAsync(id);
            if (account == null)
                return NotFound("No account with requested id");

            if (account.UserId != _identityService.GetUserId())
                return Unauthorized("This account is owned by a different user.");


            await _accountRepository.DeleteAccount(account);

            return Ok();
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<AccountInfoViewModel>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAccounts()
        {
            var userId = _identityService.GetUserId();
            var res = (await _accountRepository.GetAccountsByUserAsync(userId)).Select(e=> new AccountInfoViewModel(e));
            return Ok(res);
        }
    }
}