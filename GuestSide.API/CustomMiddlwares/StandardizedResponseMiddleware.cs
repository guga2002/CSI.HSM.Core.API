public class ForceHttp200Except500Middleware
{
    private readonly RequestDelegate _next;

    public ForceHttp200Except500Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context);

        memStream.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(memStream).ReadToEndAsync();
        memStream.Seek(0, SeekOrigin.Begin);

        int originalStatusCode = context.Response.StatusCode;

        // Let HTTP 500 errors pass through as-is
        if (originalStatusCode != 500)
        {
            context.Response.StatusCode = 200; 
        }

       context.Response.StatusCode = 200;

        context.Response.Body = originalBody;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(responseBody);
    }
}
