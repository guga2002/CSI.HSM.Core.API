using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Notification;
using Core.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : CSIControllerBase<NotificationDto, NotificationResponseDto, long, Notifications>
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            IService<NotificationDto, NotificationResponseDto, long, Notifications> serviceProvider,
            IAdditionalFeatures<NotificationDto, NotificationResponseDto, long, Notifications> additionalFeatures,
            INotificationService notificationService)
            : base(serviceProvider, additionalFeatures)
        {
            _notificationService = notificationService;
        }

        [HttpGet("unsent")]
        [SwaggerOperation(Summary = "Retrieve Unsent Notifications", Description = "Fetches all unsent notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Unsent notifications retrieved successfully.", typeof(Response<IEnumerable<NotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No unsent notifications found.")]
        public async Task<Response<IEnumerable<NotificationResponseDto>>> GetUnsentNotifications()
        {
            var result = await _notificationService.GetUnsentNotifications();
            return result.Any()
                ? Response<IEnumerable<NotificationResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<NotificationResponseDto>>.ErrorResponse("No unsent notifications found.");
        }

        [HttpGet("priority/{priority:int}")]
        [SwaggerOperation(Summary = "Retrieve Notifications by Priority", Description = "Fetches notifications filtered by priority.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Notifications retrieved successfully.", typeof(Response<IEnumerable<NotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found for the given priority.")]
        public async Task<Response<IEnumerable<NotificationResponseDto>>> GetNotificationsByPriority([FromRoute] NotificationPriority priority)
        {
            var result = await _notificationService.GetNotificationsByPriority(priority);
            return result.Any()
                ? Response<IEnumerable<NotificationResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<NotificationResponseDto>>.ErrorResponse("No notifications found for the given priority.");
        }

        [HttpPatch("mark-as-sent/{notificationId:long}")]
        [SwaggerOperation(Summary = "Mark a Notification as Sent", Description = "Updates a notification's status to 'sent'.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Notification marked as sent successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found.")]
        public async Task<Response<bool>> MarkNotificationAsSent([FromRoute] long notificationId)
        {
            var result = await _notificationService.MarkNotificationAsSent(notificationId);
            return result
                ? Response<bool>.SuccessResponse(true, "Notification marked as sent successfully.")
                : Response<bool>.ErrorResponse("Notification not found.");
        }

        [HttpGet("date-range")]
        [SwaggerOperation(Summary = "Retrieve Notifications by Date Range", Description = "Fetches notifications within a specific date range.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Notifications retrieved successfully.", typeof(Response<IEnumerable<NotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found within the given date range.")]
        public async Task<Response<IEnumerable<NotificationResponseDto>>> GetNotificationsByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await _notificationService.GetNotificationsByDateRange(start, end);
            return result.Any()
                ? Response<IEnumerable<NotificationResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<NotificationResponseDto>>.ErrorResponse("No notifications found within the given date range.");
        }

        [HttpGet("latest/{count:int}")]
        [SwaggerOperation(Summary = "Retrieve Latest Notifications", Description = "Fetches the latest notifications up to a specified count.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Latest notifications retrieved successfully.", typeof(Response<IEnumerable<NotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No recent notifications found.")]
        public async Task<Response<IEnumerable<NotificationResponseDto>>> GetLatestNotifications([FromRoute] int count)
        {
            var result = await _notificationService.GetLatestNotifications(count);
            return result.Any()
                ? Response<IEnumerable<NotificationResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<NotificationResponseDto>>.ErrorResponse("No recent notifications found.");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Notifications", Description = "Returns all notification records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<NotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<NotificationResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Notification by ID", Description = "Fetches a specific notification record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<NotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<NotificationResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Notification", Description = "Adds a new notification record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<NotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<NotificationResponseDto>> CreateAsync([FromBody] NotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Notification", Description = "Updates an existing notification record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<NotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<NotificationResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] NotificationDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Notification", Description = "Deletes a notification record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<NotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<NotificationResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Notifications", Description = "Deletes multiple notification records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<NotificationDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Notifications", Description = "Updates multiple notification records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<NotificationDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Notifications", Description = "Adds multiple notification records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<NotificationDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Notification", Description = "Marks a notification record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<NotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<NotificationResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
