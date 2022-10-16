using BudgetTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetTrack.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccountBalance> UserAccountBalance { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
