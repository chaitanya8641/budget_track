using BudgetTrack.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BudgetTrack.API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;

        public BaseController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        [NonAction]
        public string GetUserId()
        {
            var user = User.Claims?.ToList().Find(x => x.Type == "UserId")?.Value;
            if(user == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User not found");
            }
            return user;
        }
    }
}
