using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Wallet.Services.Currency.Domain.Repositories;

namespace Wallet.Services.Currency.Controllers
{
    [Route("/api/v1/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }


        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCurrencies()
        {
            return Ok(await _currencyRepository.GetItemsAsync());
        }
    }
}
