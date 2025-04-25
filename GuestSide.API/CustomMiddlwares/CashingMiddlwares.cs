using System.Net;
using System.Text.Json;
using Core.Persistance.Cashing;

namespace Core.API.CustomMiddlwares
{
    public class CashingMiddlwares
    {
        private readonly RequestDelegate _next;
        // private readonly ILogger<CashingMiddlwares> _logger;
        private readonly IRedisCash _redisCache;

        public CashingMiddlwares(RequestDelegate next, IRedisCash redisCache)
        {
            _next = next;
            _redisCache = redisCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            var query = context.Request.QueryString.Value;
            var userId = context.User?.Identity?.Name ?? "anonymous";
            var language = context.Request.Headers["X-Hotel-Id"].ToString();

            var cacheKey = $"{path}{query}|User:{userId}|Lang:{language}";

            var cachedResponse = await _redisCache.GetCache<string>(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(cachedResponse);
                return;
            }

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    await HandleError(context, ex);
                    return;
                }

                responseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyString = new StreamReader(responseBody).ReadToEnd();

                await _redisCache.SetCache(cacheKey, responseBodyString, TimeSpan.FromMinutes(1));

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private Task HandleError(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                context.Response.StatusCode,
                ex.Message,
                Detailed = ex.Source
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
