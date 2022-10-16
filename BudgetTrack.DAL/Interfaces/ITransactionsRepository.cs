using BudgetTrack.Domain.DTOs.Transactions;
using BudgetTrack.Domain.Entities;

namespace BudgetTrack.DAL.Interfaces
{
    public interface ITransactionsRepository : IGenericRepository<UserTransaction>
    {
    }
}
