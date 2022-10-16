using BudgetTrack.Domain.DTOs.Transactions;

namespace BudgetTrack.BAL.Interfaces
{
    public interface IUserTransactionService
    {
        Task<IEnumerable<UserTransactionDTO>> GetUserTransactions(Guid userId);
        Task<UserTransactionDTO> GetUserTransaction(Guid transactionId);
        Task<UserTransactionDTO> AddUserTransaction(AddUserTransactionDTO userTransactionDTO);
        Task<UserTransactionDTO> UpdateUserTransaction(UserUpdateTransactionDTO userUpdateTransactionDTO);
        Task<int> DeleteUserTransaction(UserTransactionDTO userTransaction);
    }
}
