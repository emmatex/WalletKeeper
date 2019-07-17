namespace Wallet.Services.Transactions.Domain.Models
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
