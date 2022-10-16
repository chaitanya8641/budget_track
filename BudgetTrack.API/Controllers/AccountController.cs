using BudgetTrack.BAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IUserAccountBalanceService _userAccountBalanceService;
        public AccountController(IUserAccountBalanceService userAccountBalanceService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userAccountBalanceService = userAccountBalanceService;
        }
        [HttpGet("GetAccountBalance")]
        public async Task<IActionResult> GetAccountBalance(Guid userId, string type)
        {
            var accountBalabce = await _userAccountBalanceService.GetBalance(type, userId);
            return Ok(accountBalabce);
        }
    }
}
