using Core.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core.API.Extensions
{
    public static class ControllerBaseExtension
    {
        /// <summary>
        /// Checks if the user is authenticated.
        /// </summary>
        public static bool UserActive(this ControllerBase controller)
        {
            return controller?.User?.Identity?.IsAuthenticated ?? false;
        }

        /// <summary>
        /// Checks if the authenticated user belongs to a specified role.
        /// </summary>
        public static bool IsUserInRole(this ControllerBase controller, string role)
        {
            return controller?.User?.IsInRole(role) ?? false;
        }

        /// <summary>
        /// Retrieves the unique identifier of the authenticated user.
        /// </summary>
        public static string GetUserId(this ControllerBase controller)
        {
            return controller?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        /// <summary>
        /// Retrieves the email address of the authenticated user.
        /// </summary>
        public static string GetUserEmail(this ControllerBase controller)
        {
            return controller?.User?.FindFirst(ClaimTypes.Email)?.Value;
        }

        /// <summary>
        /// Checks if the authenticated user has a specific claim.
        /// </summary>
        public static bool HasClaim(this ControllerBase controller, string claimType, string claimValue)
        {
            return controller?.User?.HasClaim(claimType, claimValue) ?? false;
        }

        /// <summary>
        /// Creates a standardized response for success and failure cases.
        /// </summary>
        public static IActionResult CreateResponse<T>(this ControllerBase controller, T data, string successMessage = null, string errorMessage = null)
        {
            if (data == null)
            {
                return controller.BadRequest(new { Message = errorMessage ?? "Data not found." });
            }
            return controller.Ok(new { Data = data, Message = successMessage ?? "Operation successful." });
        }

        /// <summary>
        /// Retrieves the IP address of the incoming request.
        /// </summary>
        public static string GetClientIpAddress(this ControllerBase controller)
        {
            return controller.HttpContext.Connection.RemoteIpAddress?.ToString();
        }

        /// <summary>
        /// Checks if the request is an AJAX request.
        /// </summary>
        public static bool IsAjaxRequest(this ControllerBase controller)
        {
            return controller.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }



        /// <summary>
        /// Logs an information message.
        /// </summary>
        public static void LogInformation(this ControllerBase controller, string message)
        {
            var logger = controller.HttpContext.RequestServices.GetService<ILogger<ControllerBase>>();
            logger?.LogInformation(message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        public static void LogWarning(this ControllerBase controller, string message)
        {
            var logger = controller.HttpContext.RequestServices.GetService<ILogger<ControllerBase>>();
            logger?.LogWarning(message);
        }

        /// <summary>
        /// Logs an error message with exception details.
        /// </summary>
        public static void LogError(this ControllerBase controller, string message, Exception exception)
        {
            var logger = controller.HttpContext.RequestServices.GetService<ILogger<ControllerBase>>();
            logger?.LogError(exception, message);
        }

        /// <summary>
        /// Creates a "201 Created" response with the location of the created resource.
        /// </summary>
        public static IActionResult CreatedResponse<T>(this ControllerBase controller, string uri, T data) =>
            controller.Created(uri, new { Data = data });

        /// <summary>
        /// Creates a "204 No Content" response.
        /// </summary>
        public static IActionResult NoContentResponse(this ControllerBase controller) =>
            controller.NoContent();

        /// <summary>
        /// Checks if the user is in any of the specified roles.
        /// </summary>
        public static bool IsUserInAnyRole(this ControllerBase controller, params string[] roles) =>
            roles.Any(role => controller.IsUserInRole(role));

        /// <summary>
        /// Retrieves the user's claims as a dictionary for easy access.
        /// </summary>
        public static Dictionary<string, string> GetClaimsAsDictionary(this ControllerBase controller) =>
            controller.User.Claims.ToDictionary(c => c.Type, c => c.Value);

        /// <summary>
        /// Validates the model state and returns a bad request response if invalid.
        /// </summary>
        public static IActionResult ValidateModel(this ControllerBase controller)
        {
            if (!controller.ModelState.IsValid)
            {
                return controller.BadRequest(controller.ModelState);
            }
            return null; // Return null if the model is valid
        }

    }
}
