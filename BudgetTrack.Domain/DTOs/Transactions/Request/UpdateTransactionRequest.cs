
using BudgetTrack.Domain.Enums;

namespace BudgetTrack.Domain.DTOs.Transactions.Request
{
    public class UpdateTransactionRequest
    {
        public Guid TransactionId { get; set; }
        public string TransactionName { get; set; } = null!;
        public decimal TransactionAmount { get; set; }
    }
}
