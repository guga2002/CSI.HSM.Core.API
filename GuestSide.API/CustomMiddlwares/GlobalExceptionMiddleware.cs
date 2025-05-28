using System.Net;
using System.Text.Json;
using Generic.API.ResponseClass;

namespace Core.API.CustomMiddlwares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new Response<object>
            {
                success = false,
                message = "An unexpected error occurred.",
                statusCode = 500,
                errors = new List<string> { ex.Message }
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

}