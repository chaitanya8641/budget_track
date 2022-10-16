using System.Net;

namespace BudgetTrack.API.Exceptions
{
    public class ExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsHandlingMiddleware> _logger;

        public ExceptionsHandlingMiddleware(RequestDelegate next, ILogger<ExceptionsHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpException ex)
            {
                await HandleHttpExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleUnhandledExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleHttpExceptionAsync(HttpContext context, HttpException exception)
        {
            _logger.LogError(exception, exception.MessageDetail ?? exception.Message);

            if (!context.Response.HasStarted)
            {
                int statusCode = exception.StatusCode;
                string message = exception.Message;
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                var result = new ExceptionMessage(message).ToString();
                await context.Response.WriteAsync(result);
            }
        }

        private async Task HandleUnhandledExceptionAsync(HttpContext context, Exception exception)
        {

            _logger.LogError(exception, exception.Message);

            if (!context.Response.HasStarted)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError; // 500
                string message = exception.Message;
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var result = new ExceptionMessage(message).ToString();
                await context.Response.WriteAsync(result);
            }
        }
    }
}
