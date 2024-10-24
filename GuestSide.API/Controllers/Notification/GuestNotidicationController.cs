using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestNotificationController : CSIControllerBase<GuestNotificationDto, long, GuestNotification>
    {
        public GuestNotificationController(IService<GuestNotificationDto, long, GuestNotification> service) : base(service)
        {
        }

        /// <summary>
        /// Retrieves all guest notifications.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all guest notifications.</returns>
        [HttpGet("GetNotifications")]
        [SwaggerOperation(Summary = "Retrieve all guest notifications", Description = "Returns a list of all guest notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved notifications.", typeof(Response<IEnumerable<GuestNotificationDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
        public override Task<Response<IEnumerable<GuestNotificationDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific guest notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest notification.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The guest notification matching the specified ID.</returns>
        [HttpGet("GetNotificationById/{id}")]
        [SwaggerOperation(Summary = "Retrieve guest notification by ID", Description = "Returns a specific guest notification by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the guest notification.", typeof(Response<GuestNotificationDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest notification not found.")]
        public override Task<Response<GuestNotificationDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new guest notification.
        /// </summary>
        /// <param name="entityDto">The guest notification to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created guest notification.</returns>
        [HttpPost("CreateNotification")]
        [SwaggerOperation(Summary = "Create a new guest notification", Description = "Creates a new guest notification.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Guest notification created successfully.", typeof(Response<GuestNotificationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<GuestNotificationDto>> CreateAsync([FromBody] GuestNotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing guest notification.
        /// </summary>
        /// <param name="id">The ID of the guest notification to update.</param>
        /// <param name="entityDto">The updated guest notification data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated guest notification.</returns>
        [HttpPut("UpdateNotification/{id}")]
        [SwaggerOperation(Summary = "Update an existing guest notification", Description = "Updates the guest notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest notification updated successfully.", typeof(Response<GuestNotificationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<GuestNotificationDto>> UpdateAsync([FromRoute] long id, [FromBody] GuestNotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a guest notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest notification to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteNotification/{id}")]
        [SwaggerOperation(Summary = "Delete a guest notification", Description = "Deletes the guest notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest notification deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest notification not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
