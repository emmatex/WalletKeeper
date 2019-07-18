using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Wallet.Services.Currency.Infrastructure
{
    public class CurrenciesDbContext:DbContext
    {
        public CurrenciesDbContext(DbContextOptions<CurrenciesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CurrencyConfiguration());
        }

        public void Seed()
        {
            if (!Currencies.Any())
            {
                List<Domain.Models.Currency> currencies = new List<Domain.Models.Currency>();
                string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure",
                    "currencies.json"));

                var jObject = JObject.Parse(json);

                foreach (var property in jObject.Properties())
                {
                    var currency = new Domain.Models.Currency
                    {
                        Code = property.Name,
                        Title = property.First["name"].Value<string>(),
                        Symbol = property.First["symbol"].Value<string>(),
                    };
                    currencies.Add(currency);
                }

                Currencies.AddRange(currencies);
                SaveChanges();
            }
        }
    }
}