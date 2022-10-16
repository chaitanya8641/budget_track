using BudgetTrack.Domain.Enums;

namespace BudgetTrack.Domain.DTOs.Transactions.Request
{
    public class AddTransactionRequest
    {
        public string TransactionName { get; set; } = null!;
        public decimal TransactionAmount { get; set; }
        public TransactionType Type { get; set; }
    }
}
