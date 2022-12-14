namespace BudgetTrack.Domain.DTOs.Transactions
{
    public  class AddUserTransactionDTO
    {
        public Guid UserId { get; set; }
        public string TransactionName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Type { get; set; } = null!;
    }
    public class UserUpdateTransactionDTO : AddUserTransactionDTO
    {
        public Guid TransactionId { get; set; }
    }

}
