using Core.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.API.Fillters
{

    public class SetHttpStatusCodeFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult &&
                objectResult.Value is IHasStatusCode responseWithStatus)
            {
                context.HttpContext.Response.StatusCode = responseWithStatus.StatusCode;
            }

            await next();
        }
    }

}
