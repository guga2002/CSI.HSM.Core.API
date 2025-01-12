using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AddHotelIdHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Hotel-Id",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Hotel identifier (unique per tenant)",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}
