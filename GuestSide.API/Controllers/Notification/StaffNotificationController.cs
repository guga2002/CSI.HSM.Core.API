using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffNotificationController : CSIControllerBase<StafNotificationResponseDto, long, StaffNotification>
    {
        public StaffNotificationController(IService<StafNotificationResponseDto, long, StaffNotification> service) : base(service) { }

        /// <summary>
        /// Retrieves all staff notifications.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all staff notifications.</returns>
        [HttpGet("GetAllStaffNotifications")]
        [SwaggerOperation(Summary = "Retrieve all staff notifications", Description = "Returns a list of all staff notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved staff notifications.", typeof(Response<IEnumerable<StafNotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No staff notifications found.")]
        public override Task<Response<IEnumerable<StafNotificationResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a staff notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the staff notification.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The staff notification matching the specified ID.</returns>
        [HttpGet("GetStaffNotificationById/{id}")]
        [SwaggerOperation(Summary = "Retrieve staff notification by ID", Description = "Returns a specific staff notification by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the staff notification.", typeof(Response<StafNotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff notification not found.")]
        public override Task<Response<StafNotificationResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new staff notification.
        /// </summary>
        /// <param name="entityDto">The staff notification to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created staff notification.</returns>
        [HttpPost("CreateStaffNotification")]
        [SwaggerOperation(Summary = "Create a new staff notification", Description = "Creates a new staff notification.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Staff notification created successfully.", typeof(Response<StafNotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StafNotificationResponseDto>> CreateAsync([FromBody] StafNotificationResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing staff notification.
        /// </summary>
        /// <param name="id">The ID of the staff notification to update.</param>
        /// <param name="entityDto">The updated staff notification data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated staff notification.</returns>
        [HttpPut("UpdateStaffNotification/{id}")]
        [SwaggerOperation(Summary = "Update an existing staff notification", Description = "Updates the staff notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff notification updated successfully.", typeof(Response<StafNotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StafNotificationResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StafNotificationResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a staff notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the staff notification to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteStaffNotification/{id}")]
        [SwaggerOperation(Summary = "Delete a staff notification", Description = "Deletes the staff notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff notification deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff notification not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
