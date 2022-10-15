using BudgetTrack.API.Services.Interfaces;
using BudgetTrack.Domain.Requests;
using BudgetTrack.Domain.Responses;
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
            try
            {
                var response = await _tokenService.Authenticate(request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
