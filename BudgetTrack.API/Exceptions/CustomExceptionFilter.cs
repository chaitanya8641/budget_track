using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BudgetTrack.API.Exceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception) 
            {
                case ArgumentException:
                    context.Result = new BadRequestResult();
                    break;
                case InvalidOperationException:
                    context.Result = new NotFoundResult();
                    break;
                default:
                    context.Result = new NotFoundResult();
                    break;
            }
        }
    }
}
