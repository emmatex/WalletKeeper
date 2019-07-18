using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Services.Currency.Domain.Repositories;
using Wallet.Services.Currency.Infrastructure;

namespace Wallet.Services.Currency.Repositories
{
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly CurrenciesDbContext _context;

        public CurrencyRepository(CurrenciesDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Domain.Models.Currency>> GetItemsAsync()
        {
            return _context.Currencies.ToIEnumerableAsync();
        }
    }
}
