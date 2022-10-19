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

        [HttpGet("GetDebitAccountBalance")]
        public async Task<IActionResult> GetDebitAccountBalance()
        {
            var userId = Guid.Parse(GetUserId());
            var accountBalabce = await _userAccountBalanceService.GetDebitAccountBalance(userId);
            return Ok(accountBalabce);
        }
        [HttpGet("GetCreditAccountBalance")]
        public async Task<IActionResult> GetCreditAccountBalance()
        {
            var userId = Guid.Parse(GetUserId());
            var accountBalabce = await _userAccountBalanceService.GetCreditAccountBalance(userId);
            return Ok(accountBalabce);
        }
    }
}
