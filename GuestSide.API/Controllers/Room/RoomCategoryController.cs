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
    public class RoomCategoryController : CSIControllerBase<RoomCategoryDto, long, RoomCategory>
    {
        public RoomCategoryController(IService<RoomCategoryDto, long, RoomCategory> service) : base(service) { }

        /// <summary>
        /// Retrieves all room categories.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all room categories.</returns>
        [HttpGet("GetAllRoomCategories")]
        [SwaggerOperation(Summary = "Retrieve all room categories", Description = "Returns a list of all room categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved room categories.", typeof(Response<IEnumerable<RoomCategoryDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No room categories found.")]
        public override Task<Response<IEnumerable<RoomCategoryDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a room category by its ID.
        /// </summary>
        /// <param name="id">The ID of the room category.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The room category matching the specified ID.</returns>
        [HttpGet("GetRoomCategoryById/{id}")]
        [SwaggerOperation(Summary = "Retrieve room category by ID", Description = "Returns a specific room category by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the room category.", typeof(Response<RoomCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Room category not found.")]
        public override Task<Response<RoomCategoryDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new room category.
        /// </summary>
        /// <param name="entityDto">The room category to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created room category.</returns>
        [HttpPost("CreateRoomCategory")]
        [SwaggerOperation(Summary = "Create a new room category", Description = "Creates a new room category.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Room category created successfully.", typeof(Response<RoomCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<RoomCategoryDto>> CreateAsync([FromBody] RoomCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing room category.
        /// </summary>
        /// <param name="id">The ID of the room category to update.</param>
        /// <param name="entityDto">The updated room category data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated room category.</returns>
        [HttpPut("UpdateRoomCategory/{id}")]
        [SwaggerOperation(Summary = "Update an existing room category", Description = "Updates the room category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Room category updated successfully.", typeof(Response<RoomCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<RoomCategoryDto>> UpdateAsync([FromRoute] long id, [FromBody] RoomCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a room category by its ID.
        /// </summary>
        /// <param name="id">The ID of the room category to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteRoomCategory/{id}")]
        [SwaggerOperation(Summary = "Delete a room category", Description = "Deletes the room category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Room category deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Room category not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
