using BudgetTrack.API.Services.Interfaces;
using BudgetTrack.Domain.DTOs.Auth.Request;
using BudgetTrack.Domain.DTOs.Auth.Response;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrack.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            var response = await _tokenService.Authenticate(request);
            return Ok(response);
        }
    }
}
