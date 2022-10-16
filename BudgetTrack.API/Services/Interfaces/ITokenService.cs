using BudgetTrack.Domain.DTOs.Auth.Request;
using BudgetTrack.Domain.DTOs.Auth.Response;

namespace BudgetTrack.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResponse> Authenticate(AuthRequest authRequest);
    }
}
