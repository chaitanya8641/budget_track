using System.ComponentModel.DataAnnotations;

namespace BudgetTrack.Domain.DTOs.Auth.Request
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
