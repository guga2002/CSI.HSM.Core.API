using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Notification;
using Core.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Notification;

[Route("api/[controller]")]
[ApiController]
public class GuestNotificationController : CSIControllerBase<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>
{
    private readonly IGuestNotificationService _guestNotificationService;

    public GuestNotificationController(
        IService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification> serviceProvider,
        IAdditionalFeatures<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification> additionalFeatures,
        IGuestNotificationService guestNotificationService)
        : base(serviceProvider, additionalFeatures)
    {
        _guestNotificationService = guestNotificationService;
    }

    [HttpPatch("Guest-Notification-Mark-AsRead/{guestId:long}/{notificationId:long}")]
    [SwaggerOperation(Summary = "Mark a Notification as Read/Unread", Description = "Marks a specific guest notification as read or unread.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notification status updated successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
    public async Task<Response<GuestNotificationResponseDto>> MarkNotificationAsRead(
        [FromRoute] long guestId,
        [FromRoute] long notificationId,
        [FromQuery] bool unread = false)
    {
        var result = await _guestNotificationService.MarkGuestNotificationAsRead(guestId, notificationId, unread);
        return result is not null
            ? Response<GuestNotificationResponseDto>.SuccessResponse(result, "Notification status updated successfully.")
            : Response<GuestNotificationResponseDto>.ErrorResponse("Error updating notification status.");
    }

    [HttpGet("ByGuest/{guestId:long}")]
    [SwaggerOperation(Summary = "Retrieve Notifications by Guest ID", Description = "Fetches all notifications associated with a specific guest.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notifications retrieved successfully.", typeof(Response<IEnumerable<GuestNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
    public async Task<Response<IEnumerable<GuestNotificationResponseDto>>> GetNotificationsByGuest([FromRoute] long guestId)
    {
        var result = await _guestNotificationService.GetNotificationsByGuestId(guestId);
        return result.Any()
            ? Response<IEnumerable<GuestNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<GuestNotificationResponseDto>>.ErrorResponse("No notifications found.");
    }

    [HttpGet("Guest-Unread-Notification/{guestId:long}")]
    [SwaggerOperation(Summary = "Retrieve Unread Notifications", Description = "Fetches all unread notifications for a specific guest.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Unread notifications retrieved successfully.", typeof(Response<IEnumerable<GuestNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No unread notifications found.")]
    public async Task<Response<IEnumerable<GuestNotificationResponseDto>>> GetUnreadNotifications([FromRoute] long guestId)
    {
        var result = await _guestNotificationService.GetUnreadNotificationsByGuestId(guestId);
        return result.Any()
            ? Response<IEnumerable<GuestNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<GuestNotificationResponseDto>>.ErrorResponse("No unread notifications found.");
    }

    [HttpGet("Guest-Important/{guestId:long}")]
    [SwaggerOperation(Summary = "Retrieve Important Notifications", Description = "Fetches all important notifications for a specific guest.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Important notifications retrieved successfully.", typeof(Response<IEnumerable<GuestNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No important notifications found.")]
    public async Task<Response<IEnumerable<GuestNotificationResponseDto>>> GetImportantNotifications([FromRoute] long guestId)
    {
        var result = await _guestNotificationService.GetImportantNotificationsByGuestId(guestId);
        return result.Any()
            ? Response<IEnumerable<GuestNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<GuestNotificationResponseDto>>.ErrorResponse("No important notifications found.");
    }

    [HttpDelete("Guest-Notification-Delete/{guestId:long}/{notificationId:long}")]
    [SwaggerOperation(Summary = "Delete a Specific Guest Notification", Description = "Deletes a specific guest notification.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notification deleted successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
    public async Task<Response<bool>> DeleteGuestNotification([FromRoute] long guestId, [FromRoute] long notificationId)
    {
        var result = await _guestNotificationService.DeleteGuestNotification(guestId, notificationId);
        return result
            ? Response<bool>.SuccessResponse(true, "Notification deleted successfully.")
            : Response<bool>.ErrorResponse("Notification not found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Guest Notifications", Description = "Returns all guest notification records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<GuestNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<GuestNotificationResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Guest Notification by ID", Description = "Fetches a specific guest notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<GuestNotificationResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Guest Notification", Description = "Adds a new guest notification record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<GuestNotificationResponseDto>> CreateAsync([FromBody] GuestNotificationDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Guest Notification", Description = "Updates an existing guest notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<GuestNotificationResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] GuestNotificationDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Guest Notification", Description = "Deletes a guest notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<GuestNotificationResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Guest Notifications", Description = "Deletes multiple guest notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<GuestNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Guest Notifications", Description = "Updates multiple guest notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<GuestNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Guest Notifications", Description = "Adds multiple guest notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<GuestNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Guest Notification", Description = "Marks a guest notification record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<GuestNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<GuestNotificationResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
