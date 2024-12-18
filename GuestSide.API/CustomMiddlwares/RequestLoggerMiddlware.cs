namespace Core.API.CustomMiddlwares
{
    public class RequestLoggerMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;

        public RequestLoggerMiddleware(ILogger<RequestLoggerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Request {Method} {Path} started at {Timestamp}",
                context.Request.Method,
                context.Request.Path,
                DateTime.UtcNow);

            await next(context);

            _logger.LogInformation("Request {Method} {Path} completed at {Timestamp}",
                context.Request.Method,
                context.Request.Path,
                DateTime.UtcNow);
        }
    }
}
