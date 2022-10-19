
using BudgetTrack.Domain.DTOs.UserAccountBalance;

namespace BudgetTrack.BAL.Interfaces
{
    public interface IUserAccountBalanceService
    {
        Task<UserAccountBalanceDTO> GetDebitAccountBalance(Guid userId);
        Task<UserAccountBalanceDTO> GetCreditAccountBalance(Guid userId);
        Task<bool> UpdateAccountBalance(UserAccountBalanceDTO userAccountBalanceDTO);
    }
}
