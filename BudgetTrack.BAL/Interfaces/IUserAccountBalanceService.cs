namespace BudgetTrack.BAL.Interfaces
{
    public interface IUserAccountBalanceService
    {
        Task<decimal> GetBalance(string accountType, Guid userId);
    }
}
