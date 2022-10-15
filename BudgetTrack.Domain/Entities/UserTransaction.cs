using BudgetTrack.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetTrack.Domain.Entities
{
    public class UserTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public string? TransactionName { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TransactionAmount { get; set; }
        public Guid UserId { get; set; }
        public TransactionType Type { get; set; }
    }
}
