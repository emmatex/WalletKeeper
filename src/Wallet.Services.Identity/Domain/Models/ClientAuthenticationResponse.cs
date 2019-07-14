using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Identity.Domain.Models
{
    public class ClientAuthenticationResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
