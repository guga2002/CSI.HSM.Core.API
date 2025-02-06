using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : CSIControllerBase<RoomsDto, RoomsResponseDto, long, Rooms>
    {
        private readonly IRoomService _roomService;
        public RoomController(
            IRoomService roomService,
            IService<RoomsDto, RoomsResponseDto, long, Rooms> serviceProvider,
            IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Rooms> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _roomService = roomService;
        }

        [HttpGet("RoomDetails/{roomId:long}")]
        [SwaggerOperation(Summary = "Retrieve room details", Description = "Returns room details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<RoomsResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public async Task<Response<RoomsResponseDto>> GetRoomDetails(long roomId)
        {
            var res=await _roomService.GetRoomDetails(roomId);
            if(res is not null)
            {
                return Response<RoomsResponseDto>.SuccessResponse(res);
            }

            return Response<RoomsResponseDto>.ErrorResponse("no data exist");
        }

        [HttpGet("HotelForRoom/{roomId:long}")]
        [SwaggerOperation(Summary = "Get hotel for room", Description = "retrieve hotel")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public async Task<Response<HotelResponse>> GetHotelForRoom(long roomId)
        {
            var res = await _roomService.GetHotelForRoom(roomId);
            if (res is not null)
            {
                return Response<HotelResponse>.SuccessResponse(res);
            }

            return Response<HotelResponse>.ErrorResponse("no data exist");

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
}
