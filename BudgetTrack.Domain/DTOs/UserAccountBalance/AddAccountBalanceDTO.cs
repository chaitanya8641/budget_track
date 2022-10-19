namespace BudgetTrack.Domain.DTOs.UserAccountBalance
{
    public class AddAccountBalanceDTO
    {
        public Guid UserId { get; set; }
        public decimal AccountBalance { get; set; }
        public string Type { get; set; } = null!;
    }

    public class UpdateAccountBalanceDTO:AddAccountBalanceDTO
    {
        public Guid UserAccountBalanceId { get; set; }
    }
}
