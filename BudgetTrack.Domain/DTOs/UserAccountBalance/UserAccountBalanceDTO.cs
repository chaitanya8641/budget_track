namespace BudgetTrack.Domain.DTOs.UserAccountBalance
{
    public class UserAccountBalanceDTO
    {
        public Guid UserAccountBalanceId { get; set; }
        public Guid UserId { get; set; }
        public decimal AccountBalance { get; set; }
        public string Type { get; set; } = null!;
    }
}
