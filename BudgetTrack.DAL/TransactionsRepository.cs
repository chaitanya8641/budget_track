using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Data;
using BudgetTrack.Domain.Entities;

namespace BudgetTrack.DAL
{
    public class TransactionsRepository : GenericRepository<UserTransaction>, ITransactionsRepository
    {
        private readonly BudgetContext _budgetDbContext;
        public TransactionsRepository(BudgetContext budgetDbContext) : base(budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }
    }
}