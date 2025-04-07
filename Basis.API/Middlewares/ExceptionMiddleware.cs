using Basis.Domain.Common.Exceptions;

namespace Basis.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int status;
            IEnumerable<string> errors;

            if (exception is BaseHttpException httpEx)
            {
                status = (int)httpEx.StatusCode;
                errors = httpEx.Errors;
            }
            else
            {
                status = StatusCodes.Status500InternalServerError;
                errors = new[] { "Ocorreu um erro inesperado." };
                _logger.LogError(exception, "Erro não tratado: {Message}", exception.Message);
            }

            context.Response.StatusCode = status;

            var response = new
            {
                status,
                errors
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}