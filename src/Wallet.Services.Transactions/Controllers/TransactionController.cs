using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Services.Authentication;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Domain.Repositories;

namespace Wallet.Services.Transactions.Controllers
{
    [Route("/api/v1/[controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(IIdentityService identityService, ITransactionRepository transactionRepository)
        {
            _identityService = identityService;
            _transactionRepository = transactionRepository;
        }


        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetTransaction(Guid id)
        {
            var res = await _transactionRepository.GetTransaction(id);
            if (res == null)
                return NotFound("No transaction with the provided id was found.");

            return Ok(res);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetTransactions()
        {
            var res = await _transactionRepository.GetUserTransactions(_identityService.GetUserId());
            if (res == null)
                return NotFound("No transaction with the provided id was found.");

            return Ok(res);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            var user = _identityService.GetUserId();

            if (transaction.TypeId == (int)TransactionTypes.Income && transaction.Amount < 1)
                return BadRequest("Income transaction amount can't be less than 1.");
            if (transaction.TypeId == (int)TransactionTypes.Expense && transaction.Amount > -1)
                return BadRequest("Expense transaction amount can't be positive.");
            if (transaction.TypeId < 0 || transaction.TypeId > 2)
                return BadRequest("Invalid transaction type");

            transaction.Type = ((TransactionTypes)transaction.TypeId).ToString();
            var res = await _transactionRepository.CreateTransaction(transaction);
            var values = new {id = res.Id};
            return CreatedAtAction(nameof(GetTransaction), values, values);
        }
    }
}
