using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffToCartController : CSIControllerBase<CartToStaffDto,CartToStaffResponseDto, long, TaskToStaff>
    {
        public StaffToCartController(IService<CartToStaffDto,CartToStaffResponseDto, long, TaskToStaff> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all cart-to-staff records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all cart-to-staff records.</returns>
        [HttpGet("GetAllCartToStaff")]
        [SwaggerOperation(Summary = "Retrieve all cart-to-staff records", Description = "Returns a list of all cart-to-staff records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved cart-to-staff records.", typeof(Response<IEnumerable<CartToStaffResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No cart-to-staff records found.")]
        public override Task<Response<IEnumerable<CartToStaffResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a cart-to-staff record by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart-to-staff record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The cart-to-staff record matching the specified ID.</returns>
        [HttpGet("GetCartToStaffById/{id}")]
        [SwaggerOperation(Summary = "Retrieve cart-to-staff record by ID", Description = "Returns a specific cart-to-staff record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the cart-to-staff record.", typeof(Response<CartToStaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cart-to-staff record not found.")]
        public override Task<Response<CartToStaffResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new cart-to-staff record.
        /// </summary>
        /// <param name="entityDto">The cart-to-staff record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created cart-to-staff record.</returns>
        [HttpPost("CreateCartToStaff")]
        [SwaggerOperation(Summary = "Create a new cart-to-staff record", Description = "Creates a new cart-to-staff record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Cart-to-staff record created successfully.", typeof(Response<CartToStaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<CartToStaffResponseDto>> CreateAsync([FromBody] CartToStaffDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing cart-to-staff record.
        /// </summary>
        /// <param name="id">The ID of the cart-to-staff record to update.</param>
        /// <param name="entityDto">The updated cart-to-staff record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated cart-to-staff record.</returns>
        [HttpPut("UpdateCartToStaff/{id}")]
        [SwaggerOperation(Summary = "Update an existing cart-to-staff record", Description = "Updates the cart-to-staff record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cart-to-staff record updated successfully.", typeof(Response<CartToStaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<CartToStaffResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] CartToStaffDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a cart-to-staff record by its ID.
        /// </summary>
        /// <param name="id">The ID of the cart-to-staff record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteCartToStaff/{id}")]
        [SwaggerOperation(Summary = "Delete a cart-to-staff record", Description = "Deletes the cart-to-staff record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cart-to-staff record deleted successfully.", typeof(Response<CartToStaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cart-to-staff record not found or failed to delete.")]
        public override Task<Response<CartToStaffResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
