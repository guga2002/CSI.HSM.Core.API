using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : CSIControllerBase<RoomsDto, long, Rooms>
    {
        public RoomController(IService<RoomsDto, long, Rooms> service) : base(service) { }

        /// <summary>
        /// Retrieves all rooms.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all rooms.</returns>
        [HttpGet("GetAllRooms")]
        [SwaggerOperation(Summary = "Retrieve all rooms", Description = "Returns a list of all rooms.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved rooms.", typeof(Response<IEnumerable<RoomsDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No rooms found.")]
        public override Task<Response<IEnumerable<RoomsDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a room by its ID.
        /// </summary>
        /// <param name="id">The ID of the room.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The room matching the specified ID.</returns>
        [HttpGet("GetRoomById/{id}")]
        [SwaggerOperation(Summary = "Retrieve room by ID", Description = "Returns a specific room by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the room.", typeof(Response<RoomsDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Room not found.")]
        public override Task<Response<RoomsDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new room.
        /// </summary>
        /// <param name="entityDto">The room to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created room.</returns>
        [HttpPost("CreateRoom")]
        [SwaggerOperation(Summary = "Create a new room", Description = "Creates a new room.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Room created successfully.", typeof(Response<RoomsDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<RoomsDto>> CreateAsync([FromBody] RoomsDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing room.
        /// </summary>
        /// <param name="id">The ID of the room to update.</param>
        /// <param name="entityDto">The updated room data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated room.</returns>
        [HttpPut("UpdateRoom/{id}")]
        [SwaggerOperation(Summary = "Update an existing room", Description = "Updates the room with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Room updated successfully.", typeof(Response<RoomsDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<RoomsDto>> UpdateAsync([FromRoute] long id, [FromBody] RoomsDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a room by its ID.
        /// </summary>
        /// <param name="id">The ID of the room to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteRoom/{id}")]
        [SwaggerOperation(Summary = "Delete a room", Description = "Deletes the room with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Room deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Room not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
