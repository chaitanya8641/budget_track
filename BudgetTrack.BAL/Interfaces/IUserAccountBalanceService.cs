namespace BudgetTrack.BAL.Interfaces
{
    public interface IUserAccountBalanceService
    {
        Task<decimal> GetDebitAccountBalance(Guid userId);
        Task<decimal> GetCreditAccountBalance(Guid userId);
    }
}
