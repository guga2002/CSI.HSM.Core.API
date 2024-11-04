using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : CSIControllerBase<ItemCategoryResponseDto, long, ItemCategory>
    {
        public ItemCategoryController(IService<ItemCategoryResponseDto, long, ItemCategory> service) : base(service) { }

        /// <summary>
        /// Retrieves all item category records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all item category records.</returns>
        [HttpGet("GetItemCategories")]
        [SwaggerOperation(Summary = "Retrieve all item category records", Description = "Returns a list of all item category records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved item category records.", typeof(Response<IEnumerable<ItemCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No item category records found.")]
        public override Task<Response<IEnumerable<ItemCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific item category record by its ID.
        /// </summary>
        /// <param name="id">The ID of the item category record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The item category record matching the specified ID.</returns>
        [HttpGet("GetItemCategoryById/{id}")]
        [SwaggerOperation(Summary = "Retrieve item category record by ID", Description = "Returns a specific item category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the item category record.", typeof(Response<ItemCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item category record not found.")]
        public override Task<Response<ItemCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new item category record.
        /// </summary>
        /// <param name="entityDto">The item category record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created item category record.</returns>
        [HttpPost("CreateItemCategory")]
        [SwaggerOperation(Summary = "Create a new item category record", Description = "Creates a new item category record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item category record created successfully.", typeof(Response<ItemCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<ItemCategoryResponseDto>> CreateAsync([FromBody] ItemCategoryResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing item category record.
        /// </summary>
        /// <param name="id">The ID of the item category record to update.</param>
        /// <param name="entityDto">The updated item category record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated item category record.</returns>
        [HttpPut("UpdateItemCategory/{id}")]
        [SwaggerOperation(Summary = "Update an existing item category record", Description = "Updates the item category record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item category record updated successfully.", typeof(Response<ItemCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<ItemCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] ItemCategoryResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes an item category record by its ID.
        /// </summary>
        /// <param name="id">The ID of the item category record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteItemCategory/{id}")]
        [SwaggerOperation(Summary = "Delete an item category record", Description = "Deletes the item category record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item category record deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item category record not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
