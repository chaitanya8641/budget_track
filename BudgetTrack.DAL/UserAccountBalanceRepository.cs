using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Data;
using BudgetTrack.Domain.Entities;

namespace BudgetTrack.DAL
{
    public class UserAccountBalanceRepository : GenericRepository<UserAccountBalance>, IUserAccountBalanceRepository
    {
        private readonly BudgetContext _budgetDbContext;
        public UserAccountBalanceRepository(BudgetContext budgetDbContext) : base(budgetDbContext)
        {
            _budgetDbContext = budgetDbContext;
        }
    }
}
