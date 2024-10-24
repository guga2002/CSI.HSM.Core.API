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
    public class NotificationController : CSIControllerBase<NotificationDto, long, Notifications>
    {
        public NotificationController(IService<NotificationDto, long, Notifications> service) : base(service) { }

        /// <summary>
        /// Retrieves all notifications.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all notifications.</returns>
        [HttpGet("GetAllNotifications")]
        [SwaggerOperation(Summary = "Retrieve all notifications", Description = "Returns a list of all notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved notifications.", typeof(Response<IEnumerable<NotificationDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
        public override Task<Response<IEnumerable<NotificationDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the notification.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The notification matching the specified ID.</returns>
        [HttpGet("GetNotificationById/{id}")]
        [SwaggerOperation(Summary = "Retrieve notification by ID", Description = "Returns a specific notification by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the notification.", typeof(Response<NotificationDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
        public override Task<Response<NotificationDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new notification.
        /// </summary>
        /// <param name="entityDto">The notification to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created notification.</returns>
        [HttpPost("CreateNotification")]
        [SwaggerOperation(Summary = "Create a new notification", Description = "Creates a new notification.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Notification created successfully.", typeof(Response<NotificationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<NotificationDto>> CreateAsync([FromBody] NotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing notification.
        /// </summary>
        /// <param name="id">The ID of the notification to update.</param>
        /// <param name="entityDto">The updated notification data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated notification.</returns>
        [HttpPut("UpdateNotification/{id}")]
        [SwaggerOperation(Summary = "Update an existing notification", Description = "Updates the notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Notification updated successfully.", typeof(Response<NotificationDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<NotificationDto>> UpdateAsync([FromRoute] long id, [FromBody] NotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the notification to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteNotification/{id}")]
        [SwaggerOperation(Summary = "Delete a notification", Description = "Deletes the notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Notification deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
