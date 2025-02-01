using System.Threading;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Application.Services.Notification.DI;
using GuestSide.Core.Entities.Notification;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Notification
{
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

        [HttpGet("MarkGuestNotificationAsRead/{GuestId:long}/{NotificationId:long}")]
        [SwaggerOperation(Summary = "Mark notification as read", Description = "return  update notification")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<GuestNotificationResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public async Task<Response<GuestNotificationResponseDto>> MarkGuestNotificationAsRead(long GuestId, long NotificationId, [FromQuery]bool unread = false)
        {
          var res=await _guestNotificationService.MarkGuestNotificationAsRead(GuestId, NotificationId, unread);
            if(res is not null)
            {
                return Response< GuestNotificationResponseDto>.SuccessResponse(res);
            }

            return Response<GuestNotificationResponseDto>.ErrorResponse("error while prioccessing mark notification as unread/Read");
        }

        [HttpGet("GetNotificationsByGuestId/{GuestId:long}")]
        [SwaggerOperation(Summary = "Get nortifications", Description = "by guest Id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<GuestNotificationResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public async Task<Response<IEnumerable<GuestNotificationResponseDto>>> GetNotificationsByGuestId(long GuestId)
        {
            var res = await _guestNotificationService.GetNotificationsByGuestId(GuestId);
            if (res is not null)
            {
                return Response<IEnumerable<GuestNotificationResponseDto>>.SuccessResponse(res);
            }

            return Response<IEnumerable<GuestNotificationResponseDto>>.ErrorResponse("error while fetch Notitfcations");
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
}
