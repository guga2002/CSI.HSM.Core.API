using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.API.Fillters
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasFormFile = context.ApiDescription.ParameterDescriptions
                .Any(p => p.Type == typeof(IFormFile) || p.Type == typeof(IFormFileCollection));

            if (!hasFormFile)
                return;

            operation.RequestBody = new OpenApiRequestBody
            {
                Content =
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = context.ApiDescription.ParameterDescriptions.ToDictionary(
                            p => p.Name,
                            p =>
                            {
                                var schema = new OpenApiSchema { Type = "string", Format = "binary" };
                                if (p.Type != typeof(IFormFile))
                                    schema.Format = null;
                                return schema;
                            })
                    }
                }
            }
            };
        }
    }
}
