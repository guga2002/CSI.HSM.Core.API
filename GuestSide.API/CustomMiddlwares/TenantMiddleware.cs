namespace Core.API.CustomMiddlwares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public TenantMiddleware(RequestDelegate next, IConfiguration configuration, IWebHostEnvironment env)
        {
            _next = next;
            _configuration = configuration;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId) || string.IsNullOrWhiteSpace(hotelId))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("X-Hotel-Id header is required.");
                return;
            }
            var connectionString = _configuration.GetConnectionString(hotelId);
            if (!_env.IsProduction())
            {
                connectionString = _configuration.GetSection("connectionTest:CSICOnnect").Value;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Connection string for the hotel not found.");
                return;
            }

            context.Items["ConnectionString"] = connectionString;
            await _next(context);
        }
    }

}
