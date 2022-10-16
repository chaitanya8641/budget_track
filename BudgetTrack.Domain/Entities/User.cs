using System.ComponentModel.DataAnnotations;

namespace BudgetTrack.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
