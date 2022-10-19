using BudgetTrack.Domain.Enums;

namespace BudgetTrack.Domain.DTOs.UserAccountBalance
{
    public class UserAccountBalanceDTO
    {
        public Guid UserAccountBalanceId { get; set; }
        public Guid UserId { get; set; }
        public decimal AccounrBalance { get; set; }
    }
}
