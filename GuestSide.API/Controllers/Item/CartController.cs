using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : CSIControllerBase<CartDto,CartResponseDto, long, Cart>
    {
        public CartController(IService<CartDto,CartResponseDto, long, Cart> service) : base(service) { }

        /// <summary>
        /// Retrieves all cart records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all cart records.</returns>
        [HttpGet("GetCarts")]
        [SwaggerOperation(Summary = "Retrieve all cart records", Description = "Returns a list of all cart records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved cart records.", typeof(Response<IEnumerable<CartResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No cart records found.")]
        public override Task<Response<IEnumerable<CartResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific cart record by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The cart record matching the specified ID.</returns>
        [HttpGet("GetCartById/{id}")]
        [SwaggerOperation(Summary = "Retrieve cart record by ID", Description = "Returns a specific cart record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the cart record.", typeof(Response<CartResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cart record not found.")]
        public override Task<Response<CartResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new cart record.
        /// </summary>
        /// <param name="entityDto">The cart record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created cart record.</returns>
        [HttpPost("CreateCart")]
        [SwaggerOperation(Summary = "Create a new cart record", Description = "Creates a new cart record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Cart record created successfully.", typeof(Response<CartResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<CartResponseDto>> CreateAsync([FromBody] CartDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing cart record.
        /// </summary>
        /// <param name="id">The ID of the cart record to update.</param>
        /// <param name="entityDto">The updated cart record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated cart record.</returns>
        [HttpPut("UpdateCart/{id}")]
        [SwaggerOperation(Summary = "Update an existing cart record", Description = "Updates the cart record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cart record updated successfully.", typeof(Response<CartResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<CartResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] CartDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a cart record by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteCart/{id}")]
        [SwaggerOperation(Summary = "Delete a cart record", Description = "Deletes the cart record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cart record deleted successfully.", typeof(Response<CartResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cart record not found or failed to delete.")]
        public override Task<Response<CartResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more services or inject other features as needed.
    }
}
