using System.ComponentModel.DataAnnotations;

namespace BudgetTrack.Domain.Requests
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
