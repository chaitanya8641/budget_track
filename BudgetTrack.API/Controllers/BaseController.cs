using Microsoft.AspNetCore.Mvc;

namespace BudgetTrack.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;

        public BaseController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        [NonAction]
        public string GetUserId() => User.Claims.ToList().Find(x => x.Type == "UserId").Value;
    }
}
