using BudgetTrack.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetTrack.Domain.Entities
{
    public class UserTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public string TransactionName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Type { get; set; } = null!;
    }
}
