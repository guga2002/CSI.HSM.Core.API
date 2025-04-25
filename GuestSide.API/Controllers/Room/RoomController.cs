using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Room;
using Domain.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Room;

[Route("api/[controller]")]
[ApiController]
public class RoomController : CSIControllerBase<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room>
{
    private readonly IRoomService _roomService;

    public RoomController(
        IRoomService roomService,
        IService<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room> serviceProvider,
        IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Domain.Core.Entities.Room.Room> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _roomService = roomService;
    }

    [HttpGet("GetHotelForRoom/{roomId:long}")]
    [SwaggerOperation(Summary = "Retrieve Available HotelResponse", Description = "Fetches available rooms by hotel, category, and occupancy.")]
    [SwaggerResponse(StatusCodes.Status200OK, "HotelResponse retrieved successfully.", typeof(Response<HotelResponse>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No available rooms found.")]
    public async Task<Response<HotelResponse>> GetHotelForRoomAsync([FromRoute] long roomId)
    {
        var result = await _roomService.GetHotelForRoomAsync(roomId);
        return result is not null
            ? Response<HotelResponse>.SuccessResponse(result)
            : Response<HotelResponse>.ErrorResponse("No available rooms found.");
    }

    [HttpGet("available")]
    [SwaggerOperation(Summary = "Retrieve Available Rooms", Description = "Fetches available rooms by hotel, category, and occupancy.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Available rooms retrieved successfully.", typeof(Response<IEnumerable<RoomsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No available rooms found.")]
    public async Task<Response<IEnumerable<RoomsResponseDto>>> GetAvailableRooms(
        [FromQuery] long hotelId,
        [FromQuery] long categoryId,
        [FromQuery] int maxOccupancy,
        [FromQuery] decimal maxPrice)
    {
        var result = await _roomService.GetAvailableRooms(hotelId, categoryId, maxOccupancy, maxPrice);
        return result.Any()
            ? Response<IEnumerable<RoomsResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<RoomsResponseDto>>.ErrorResponse("No available rooms found.");
    }

    [HttpPatch("mark-unavailable/{roomId:long}")]
    [SwaggerOperation(Summary = "Mark Room as Unavailable", Description = "Marks a specific room as unavailable.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Room marked as unavailable.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Room not found.")]
    public async Task<Response<bool>> MarkRoomAsUnavailable([FromRoute] long roomId)
    {
        var result = await _roomService.MarkRoomAsUnavailable(roomId);
        return result
            ? Response<bool>.SuccessResponse(true, "Room marked as unavailable.")
            : Response<bool>.ErrorResponse("Room not found.");
    }

    [HttpPatch("update-price/{roomId:long}")]
    [SwaggerOperation(Summary = "Update Room Price", Description = "Updates the price of a specific room.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Room price updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Room not found.")]
    public async Task<Response<bool>> UpdateRoomPrice([FromRoute] long roomId, [FromBody] decimal newPrice)
    {
        var result = await _roomService.UpdateRoomPrice(roomId, newPrice);
        return result
            ? Response<bool>.SuccessResponse(true, "Room price updated successfully.")
            : Response<bool>.ErrorResponse("Room not found.");
    }

    [HttpGet("by-hotel/{hotelId:long}")]
    [SwaggerOperation(Summary = "Retrieve Rooms by Hotel", Description = "Fetches all rooms associated with a specific hotel.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Rooms retrieved successfully.", typeof(Response<IEnumerable<RoomsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No rooms found for this hotel.")]
    public async Task<Response<IEnumerable<RoomsResponseDto>>> GetRoomsByHotel([FromRoute] long hotelId)
    {
        var result = await _roomService.GetRoomsByHotel(hotelId);
        return result.Any()
            ? Response<IEnumerable<RoomsResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<RoomsResponseDto>>.ErrorResponse("No rooms found for this hotel.");
    }


    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Rooms", Description = "Returns all room records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<RoomsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<RoomsResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Room by ID", Description = "Fetches a specific room record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<RoomsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<RoomsResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Room", Description = "Adds a new room record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<RoomsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<RoomsResponseDto>> CreateAsync([FromBody] RoomsDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Room", Description = "Updates an existing room record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<RoomsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<RoomsResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] RoomsDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Room", Description = "Deletes a room record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<RoomsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<RoomsResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Rooms", Description = "Deletes multiple room records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<RoomsDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Rooms", Description = "Updates multiple room records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<RoomsDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Rooms", Description = "Adds multiple room records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<RoomsDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Room", Description = "Marks a room record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<RoomsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<RoomsResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
