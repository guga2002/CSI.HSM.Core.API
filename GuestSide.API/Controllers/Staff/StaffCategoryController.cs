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
    public class StaffCategoryController : CSIControllerBase<StaffCategoryResponseDto, long, StaffCategory>
    {
        public StaffCategoryController(IService<StaffCategoryResponseDto, long, StaffCategory> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all staff categories.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all staff categories.</returns>
        [HttpGet("GetAllStaffCategories")]
        [SwaggerOperation(Summary = "Retrieve all staff categories", Description = "Returns a list of all staff categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved staff categories.", typeof(Response<IEnumerable<StaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No staff categories found.")]
        public override Task<Response<IEnumerable<StaffCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a staff category by its ID.
        /// </summary>
        /// <param name="id">The ID of the staff category.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The staff category matching the specified ID.</returns>
        [HttpGet("GetStaffCategoryById/{id}")]
        [SwaggerOperation(Summary = "Retrieve staff category by ID", Description = "Returns a specific staff category by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the staff category.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff category not found.")]
        public override Task<Response<StaffCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new staff category.
        /// </summary>
        /// <param name="entityDto">The staff category to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created staff category.</returns>
        [HttpPost("CreateStaffCategory")]
        [SwaggerOperation(Summary = "Create a new staff category", Description = "Creates a new staff category.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Staff category created successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StaffCategoryResponseDto>> CreateAsync([FromBody] StaffCategoryResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing staff category.
        /// </summary>
        /// <param name="id">The ID of the staff category to update.</param>
        /// <param name="entityDto">The updated staff category data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated staff category.</returns>
        [HttpPut("UpdateStaffCategory/{id}")]
        [SwaggerOperation(Summary = "Update an existing staff category", Description = "Updates the staff category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff category updated successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<StaffCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffCategoryResponseDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a staff category by its ID.
        /// </summary>
        /// <param name="id">The ID of the staff category to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteStaffCategory/{id}")]
        [SwaggerOperation(Summary = "Delete a staff category", Description = "Deletes the staff category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Staff category deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Staff category not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
