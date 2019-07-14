using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Wallet.Commands;

namespace Wallet.Api.Controllers
{
    [Route("[controller]")]
    public class UserController:Controller
    {
        private readonly IBusClient _busClient;

        public UserController(IBusClient busClient)
        {
            _busClient = busClient;
        }   

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            await _busClient.PublishAsync(command);

            return Accepted();
        }
    }
}
