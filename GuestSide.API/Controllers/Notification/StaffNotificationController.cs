using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Notification;
using Domain.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Notification;

[Route("api/[controller]")]
[ApiController]
public class StaffNotificationController : CSIControllerBase<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>
{
    private readonly IStaffNotificationService _staffNotificationService;

    public StaffNotificationController(
        IService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification> serviceProvider,
        IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification> additionalFeatures,
        IStaffNotificationService staffNotificationService)
        : base(serviceProvider, additionalFeatures)
    {
        _staffNotificationService = staffNotificationService;
    }

    [HttpGet("Staff-unread/{staffId:long}")]
    [SwaggerOperation(Summary = "Retrieve Unread Notifications for Staff", Description = "Fetches unread notifications for a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Unread notifications retrieved successfully.", typeof(Response<IEnumerable<StafNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No unread notifications found.")]
    public async Task<Response<IEnumerable<StafNotificationResponseDto>>> GetUnreadNotificationsByStaffId([FromRoute] long staffId)
    {
        var result = await _staffNotificationService.GetUnreadNotificationsByStaffId(staffId);
        return result.Any()
            ? Response<IEnumerable<StafNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StafNotificationResponseDto>>.ErrorResponse("No unread notifications found.");
    }

    [HttpGet("Staff-notification/{staffId:long}")]
    [SwaggerOperation(Summary = "Retrieve all Notifications for Staff", Description = "Fetches all notifications for a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "notifications retrieved successfully.", typeof(Response<IEnumerable<StafNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
    public async Task<Response<IEnumerable<StafNotificationResponseDto>>> GetStaffNotifications([FromRoute] long staffId)
    {
        var result = await _staffNotificationService.GetStaffNotifications(staffId);
        return result.Any()
            ? Response<IEnumerable<StafNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StafNotificationResponseDto>>.ErrorResponse("No notifications found.");
    }

    [HttpGet("Staff-important/{staffId:long}")]
    [SwaggerOperation(Summary = "Retrieve Important Notifications for Staff", Description = "Fetches important notifications for a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Important notifications retrieved successfully.", typeof(Response<IEnumerable<StafNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No important notifications found.")]
    public async Task<Response<IEnumerable<StafNotificationResponseDto>>> GetImportantNotificationsByStaffId([FromRoute] long staffId)
    {
        var result = await _staffNotificationService.GetImportantNotificationsByStaffId(staffId);
        return result.Any()
            ? Response<IEnumerable<StafNotificationResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StafNotificationResponseDto>>.ErrorResponse("No important notifications found.");
    }

    [HttpPatch("Staff-mark-as-read/{staffId:long}/{notificationId:long}")]
    [SwaggerOperation(Summary = "Mark a Staff Notification as Read/Unread", Description = "Marks a staff notification as read or unread.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notification marked successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
    public async Task<Response<StafNotificationResponseDto>> MarkStaffNotificationAsRead(
        [FromRoute] long staffId,
        [FromRoute] long notificationId,
        [FromQuery] bool unread = false)
    {
        var result = await _staffNotificationService.MarkStaffNotificationAsRead(staffId, notificationId, unread);
        return result is not null
            ? Response<StafNotificationResponseDto>.SuccessResponse(result, "Notification status updated.")
            : Response<StafNotificationResponseDto>.ErrorResponse("Notification not found.");
    }

    [HttpDelete("Staff-delete/{staffId:long}/{notificationId:long}")]
    [SwaggerOperation(Summary = "Delete a Staff Notification", Description = "Deletes a specific staff notification.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notification deleted successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
    public async Task<Response<bool>> DeleteStaffNotification([FromRoute] long staffId, [FromRoute] long notificationId)
    {
        var result = await _staffNotificationService.DeleteStaffNotification(staffId, notificationId);
        return result
            ? Response<bool>.SuccessResponse(true, "Notification deleted successfully.")
            : Response<bool>.ErrorResponse("Notification not found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Staff Notifications", Description = "Returns all staff notification records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StafNotificationResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<StafNotificationResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Staff Notification by ID", Description = "Fetches a specific staff notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StafNotificationResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Staff Notification", Description = "Adds a new staff notification record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StafNotificationResponseDto>> CreateAsync([FromBody] StafNotificationDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Staff Notification", Description = "Updates an existing staff notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StafNotificationResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StafNotificationDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Staff Notification", Description = "Deletes a staff notification record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<StafNotificationResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Staff Notifications", Description = "Deletes multiple staff notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<StafNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Staff Notifications", Description = "Updates multiple staff notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<StafNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Staff Notifications", Description = "Adds multiple staff notification records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<StafNotificationDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Staff Notification", Description = "Marks a staff notification record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StafNotificationResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StafNotificationResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
