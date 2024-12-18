namespace Core.API.CustomMiddlwares
{
    public class RequestLoggerMiddleware
    {
        private readonly ILogger<RequestLoggerMiddleware> _logger;
        private readonly RequestDelegate next;
        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            _logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogDebug("Request {Method} {Path} started at {Timestamp}",
                context.Request.Method,
                context.Request.Path,
                DateTime.UtcNow);

            await next(context);

            _logger.LogDebug("Request {Method} {Path} completed at {Timestamp}",
                context.Request.Method,
                context.Request.Path,
                DateTime.UtcNow);
        }
    }
}
