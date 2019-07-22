using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Services.Authentication;
using Wallet.Services.Transactions.Domain.Models;
using Wallet.Services.Transactions.Domain.Repositories;
using Wallet.Services.Transactions.Dto;

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
        [Route("sumByType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTransactionsSumByType(int transactionType, int days)
        {
            var userId = _identityService.GetUserId();
            var res = await _transactionRepository.GetTransactionsSumByType(transactionType,days,userId);
            return Ok(res);
        }

        [HttpGet]
        [Route("getCategories/{typeId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetTransactionCategories(int typeId)
        {
            var userId = _identityService.GetUserId();
            var res = await _transactionRepository.GetTransactionCategoriesAsync(userId, typeId);
            return Ok(res);
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
        public async Task<IActionResult> CreateTransaction([FromBody]TransactionDto transactionDto)
        {
            var user = _identityService.GetUserId();

            if (transactionDto.TransactionTypeId == (int)TransactionTypes.Income && transactionDto.Amount < 1)
                return BadRequest("Income transaction amount can't be less than 1.");
            if (transactionDto.TransactionTypeId < 0 || transactionDto.TransactionTypeId > 2)
                return BadRequest("Invalid transaction type");

            var id = Guid.NewGuid();
            var transaction = new Transaction
            {
                Id = id,
                TypeId = transactionDto.TransactionTypeId,
                AccountId = transactionDto.AccountId,
                Amount = transactionDto.Amount,
                CurrencyCode = transactionDto.CurrencyCode,
                CurrencyId = transactionDto.CurrencyId,
                CurrencyTitle = transactionDto.CurrencyTitle,
                Date = transactionDto.Date,
                Notes = transactionDto.Notes,
                TransactionCategoryId = transactionDto.TransactionCategoryId,
                UserId = _identityService.GetUserId(),
                TransactionTags = transactionDto.Tags.Select(e => new TransactionTag
                {
                    TransactionId = id,
                    Tag = e
                }).ToList(),
                Type = ((TransactionTypes)transactionDto.TransactionTypeId).ToString()
            };
            var res = await _transactionRepository.CreateTransaction(transaction);
            var values = new { id = res.Id };
            return CreatedAtAction(nameof(GetTransaction), values, values);
        }
    }
}
