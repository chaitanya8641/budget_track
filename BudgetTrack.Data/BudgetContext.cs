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
        public virtual DbSet<UserTransaction> UserTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
