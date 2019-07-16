using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Services.Authentication
{
  public  class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}
