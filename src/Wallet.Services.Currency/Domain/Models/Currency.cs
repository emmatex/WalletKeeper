using System;

namespace Wallet.Services.Currency.Domain.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
