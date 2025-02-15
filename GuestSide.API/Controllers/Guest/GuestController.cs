using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Guest;
using Core.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Guest
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : CSIControllerBase<GuestDto, GuestResponseDto, long, Guests>
    {
        private readonly IGuestService _guestService;
        public GuestController(IService<GuestDto, GuestResponseDto, long, Guests> serviceProvider, IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests> additionalFeatures,
            IGuestService ser)
            : base(serviceProvider, additionalFeatures)
        {
            _guestService = ser;
        }

        [HttpGet("RoomByGuestId/{GuestId:long}")]
        [SwaggerOperation(Summary = "retrive guest room", Description = "Returns guest room")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<RoomsResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public async Task<Response<RoomsResponseDto>> GetRoomByGuestId(long GuestId)
        {
            var res = await _guestService.GetRoomByGuestId(GuestId);

            if (res is not null)
            {
                return Response<RoomsResponseDto>.SuccessResponse(res);
            }
            return Response<RoomsResponseDto>.ErrorResponse("no data exist!");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<GuestResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<GuestResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<GuestResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Guest record", Description = "Adds a new guest record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<GuestResponseDto>> CreateAsync([FromBody] GuestDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<GuestResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] GuestDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Delete a Guest record", Description = "Deletes a guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<GuestResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Guest records", Description = "Deletes multiple guest records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<GuestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Guest records", Description = "Updates multiple guest records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<GuestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Guest records", Description = "Adds multiple guest records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<GuestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:int}")]
        [SwaggerOperation(Summary = "Soft delete a Guest record", Description = "Marks a guest record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<GuestResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
