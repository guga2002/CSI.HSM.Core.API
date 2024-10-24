using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : CSIControllerBase<ItemDto, long, Items>
    {
        public ItemController(IService<ItemDto, long, Items> service) : base(service) { }

        /// <summary>
        /// Retrieves all item records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all item records.</returns>
        [HttpGet("GetItems")]
        [SwaggerOperation(Summary = "Retrieve all item records", Description = "Returns a list of all item records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved item records.", typeof(Response<IEnumerable<ItemDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No item records found.")]
        public override Task<Response<IEnumerable<ItemDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific item record by its ID.
        /// </summary>
        /// <param name="id">The ID of the item record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The item record matching the specified ID.</returns>
        [HttpGet("GetItemById/{id}")]
        [SwaggerOperation(Summary = "Retrieve item record by ID", Description = "Returns a specific item record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the item record.", typeof(Response<ItemDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item record not found.")]
        public override Task<Response<ItemDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new item record.
        /// </summary>
        /// <param name="entityDto">The item record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created item record.</returns>
        [HttpPost("CreateItem")]
        [SwaggerOperation(Summary = "Create a new item record", Description = "Creates a new item record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item record created successfully.", typeof(Response<ItemDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<ItemDto>> CreateAsync([FromBody] ItemDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing item record.
        /// </summary>
        /// <param name="id">The ID of the item record to update.</param>
        /// <param name="entityDto">The updated item record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated item record.</returns>
        [HttpPut("UpdateItem/{id}")]
        [SwaggerOperation(Summary = "Update an existing item record", Description = "Updates the item record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item record updated successfully.", typeof(Response<ItemDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<ItemDto>> UpdateAsync([FromRoute] long id, [FromBody] ItemDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes an item record by its ID.
        /// </summary>
        /// <param name="id">The ID of the item record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteItem/{id}")]
        [SwaggerOperation(Summary = "Delete an item record", Description = "Deletes the item record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item record deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item record not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
