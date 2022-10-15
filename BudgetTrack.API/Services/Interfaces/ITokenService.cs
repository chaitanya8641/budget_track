using BudgetTrack.Domain.Requests;
using BudgetTrack.Domain.Responses;

namespace BudgetTrack.API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResponse> Authenticate(AuthRequest authRequest);
    }
}
