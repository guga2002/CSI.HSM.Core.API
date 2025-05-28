using Common.Data.Entities.Guest;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Guest;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Guest;

[ApiController]
[Route("api/[controller]")]
public class GuestController : CSIControllerBase<GuestDto, GuestResponseDto, long, Guests>
{
    private readonly IGuestService _guestService;
    public GuestController(
        IService<GuestDto, GuestResponseDto, long, Guests> serviceProvider,
        IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests> additionalFeatures,
        IGuestService guestService)
        : base(serviceProvider, additionalFeatures)
    {
        _guestService = guestService;
    }


    [HttpGet("room/{guestId:long}")]
    [SwaggerOperation(Summary = "Retrieve guest room", Description = "Returns the room assigned to a guest.")]
    [ProducesResponseType(typeof(Response<RoomsResponseDto>), StatusCodes.Status200OK)]
    public async Task<Response<RoomsResponseDto?>> GetRoomByGuestIdAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.GetRoomByGuestIdAsync(guestId, cancellationToken);
        return new Response<RoomsResponseDto?>(result is not null ? true : false, result);
    }

    [HttpGet("details/{guestId:long}")]
    [SwaggerOperation(Summary = "Retrieve guest details", Description = "Fetches detailed information about a guest.")]
    [ProducesResponseType(typeof(Response<GuestResponseDto>), StatusCodes.Status200OK)]
    public async Task<Response<GuestResponseDto?>> GetGuestDetailsByIdAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.GetGuestDetailsByIdAsync(guestId, cancellationToken);
        return new Response<GuestResponseDto?>(result is not null ? true : false, result);
    }

    [HttpGet("room-guests/{roomId:long}")]
    [SwaggerOperation(Summary = "Retrieve guests by room ID", Description = "Returns a list of guests assigned to a specific room.")]
    [ProducesResponseType(typeof(Response<IEnumerable<GuestResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<GuestResponseDto>>> GetGuestsByRoomIdAsync([FromRoute] long roomId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.GetGuestsByRoomIdAsync(roomId, cancellationToken);
        return new Response<IEnumerable<GuestResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("check-exists")]
    [SwaggerOperation(Summary = "Check if guest exists", Description = "Checks whether a guest exists based on email and phone number.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> CheckGuestExistsAsync([FromQuery] string email, [FromQuery] string phoneNumber, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.CheckGuestExistsAsync(email, phoneNumber, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpPut("update-status/{guestId:long}")]
    [SwaggerOperation(Summary = "Update guest status", Description = "Updates the status of a guest.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> UpdateGuestStatusAsync([FromRoute] long guestId, [FromBody] long statusId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.UpdateGuestStatusAsync(guestId, statusId, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpGet("frequent-guests")]
    [SwaggerOperation(Summary = "Retrieve frequent guests", Description = "Returns a list of frequent guests.")]
    [ProducesResponseType(typeof(Response<IEnumerable<GuestResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<GuestResponseDto>>> GetFrequentGuestsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _guestService.GetFrequentGuestsAsync(cancellationToken);
        return new Response<IEnumerable<GuestResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpPost("assign-room/{guestId:long}")]
    [SwaggerOperation(Summary = "Assign room to guest", Description = "Assigns a guest to a specific room.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> AssignRoomToGuestAsync([FromRoute] long guestId, [FromBody] long roomId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.AssignRoomToGuestAsync(guestId, roomId, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpDelete("delete-permanently/{guestId:long}")]
    [SwaggerOperation(Summary = "Permanently delete a guest", Description = "Removes a guest record permanently from the system.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> DeleteGuestPermanentlyAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _guestService.DeleteGuestPermanentlyAsync(guestId, cancellationToken);
        return new Response<bool>(result ? true : false, result);
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
