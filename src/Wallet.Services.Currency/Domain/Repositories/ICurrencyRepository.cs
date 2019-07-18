using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Services.Currency.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Models.Currency>> GetItemsAsync();
    }
}
