using Core.Application.Interface;

namespace Core.API.Response
{
    public class Response<T>: IHasStatusCode
    {
        private bool result;
        public bool Success { get; set; } = false;
        public bool HasViewPermission { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public int StatusCode { get; set; } = 200;

        public Response() { }

        public Response(bool success, T data, string message = null, bool hasViewPermission = false, int statusCode = 200)
        {
            Success = success;
            Data = data;
            Message = message;
            HasViewPermission = hasViewPermission;
            StatusCode = statusCode;
        }

        public static Response<T> SuccessResponse(T data, string message = "Operation completed successfully.")
        {
            return new Response<T>(true, data, message, hasViewPermission: true, statusCode: 200);
        }

        public static Response<T> ErrorResponse(string message, int statusCode = 404)
        {
            return new Response<T>(false, default, message, hasViewPermission: false, statusCode: statusCode);
        }

        public static Response<T> ValidationErrorResponse(List<string> errors)
        {
            return new Response<T>(false, default, "Validation errors occurred.", hasViewPermission: false, statusCode: 422)
            {
                Errors = errors
            };
        }

        public static Response<T> UnauthorizedResponse(string message = "Unauthorized access.")
        {
            return new Response<T>(false, default, message, hasViewPermission: false, statusCode: 401);
        }
    }
}
