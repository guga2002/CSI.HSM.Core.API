using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.API.Response
{
    public class Response<T> : IActionResult
    {
        public bool Success { get; set; } = false;
        public bool HasViewPermission { get; set; } = false; // Fixed typo: "Permsiion" to "Permission"
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public int StatusCode { get; set; } = 200; // Default status code

        public Response() { }

        public Response(bool success, T data, string message = null, bool hasViewPermission = false, int statusCode = 200)
        {
            Success = success;
            Data = data;
            Message = message;
            HasViewPermission = hasViewPermission;
            StatusCode = statusCode;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            response.ContentType = "application/json";
            response.StatusCode = StatusCode;

            var jsonResponse = new
            {
                success = Success,
                hasViewPermission = HasViewPermission,
                data = Data,
                message = Message,
                errors = Errors
            };

            await response.WriteAsJsonAsync(jsonResponse);
        }

        public static Response<T> SuccessResponse(T data, string message = "Operation completed successfully.")
        {
            return new Response<T>(true, data, message);
        }

        public static Response<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new Response<T>(false, default, message, statusCode: statusCode);
        }

        public static Response<T> ValidationErrorResponse(List<string> errors)
        {
            return new Response<T>(false, default, "Validation errors occurred.", statusCode: 422)
            {
                Errors = errors
            };
        }

        public static Response<T> UnauthorizedResponse(string message = "Unauthorized access.")
        {
            return new Response<T>(false, default, message, statusCode: 401);
        }
    }
}
