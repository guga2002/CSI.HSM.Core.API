using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : CSIControllerBase<GuestDto,GuestResponseDto, long, Guests>
    {
        public GuestController(IService<GuestDto,GuestResponseDto, long, Guests> service) : base(service)
        {
        }

        /// <summary>
        /// Retrieves all guest records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all guest records.</returns>
        [HttpGet("GetGuests")]
        [SwaggerOperation(Summary = "Retrieve all guest records", Description = "Returns a list of all guest records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved guest records.", typeof(Response<IEnumerable<GuestResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No guest records found.")]
        public override Task<Response<IEnumerable<GuestResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific guest record by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The guest record matching the specified ID.</returns>
        [HttpGet("GetGuestById/{id}")]
        [SwaggerOperation(Summary = "Retrieve guest record by ID", Description = "Returns a specific guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the guest record.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest record not found.")]
        public override Task<Response<GuestResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new guest record.
        /// </summary>
        /// <param name="entityDto">The guest record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created guest record.</returns>
        [HttpPost("CreateGuest")]
        [SwaggerOperation(Summary = "Create a new guest record", Description = "Creates a new guest record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Guest record created successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<GuestResponseDto>> CreateAsync([FromBody] GuestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing guest record.
        /// </summary>
        /// <param name="id">The ID of the guest record to update.</param>
        /// <param name="entityDto">The updated guest record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated guest record.</returns>
        [HttpPut("UpdateGuest/{id}")]
        [SwaggerOperation(Summary = "Update an existing guest record", Description = "Updates the guest record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest record updated successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<GuestResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] GuestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a guest record by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteGuest/{id}")]
        [SwaggerOperation(Summary = "Delete a guest record", Description = "Deletes the guest record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest record deleted successfully.", typeof(Response<GuestResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest record not found or failed to delete.")]
        public override Task<Response<GuestResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more services or inject other features as needed.
    }
}
