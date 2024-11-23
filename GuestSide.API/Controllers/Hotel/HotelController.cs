using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Hotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : CSIControllerBase<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>
    {
        public HotelController(IService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all hotel records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all hotel records.</returns>
        [HttpGet("GetHotels")]
        [SwaggerOperation(Summary = "Retrieve all hotel records", Description = "Returns a list of all hotel records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved hotel records.", typeof(Response<IEnumerable<HotelResponse>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No hotel records found.")]
        public override Task<Response<IEnumerable<HotelResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific hotel record by its ID.
        /// </summary>
        /// <param name="id">The ID of the hotel record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The hotel record matching the specified ID.</returns>
        [HttpGet("GetHotelById/{id}")]
        [SwaggerOperation(Summary = "Retrieve hotel record by ID", Description = "Returns a specific hotel record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the hotel record.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Hotel record not found.")]
        public override Task<Response<HotelResponse>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new hotel record.
        /// </summary>
        /// <param name="entityDto">The hotel record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created hotel record.</returns>
        [HttpPost("CreateHotel")]
        [SwaggerOperation(Summary = "Create a new hotel record", Description = "Creates a new hotel record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Hotel record created successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<HotelResponse>> CreateAsync([FromBody] HotelRequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing hotel record.
        /// </summary>
        /// <param name="id">The ID of the hotel record to update.</param>
        /// <param name="entityDto">The updated hotel record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated hotel record.</returns>
        [HttpPut("UpdateHotel/{id}")]
        [SwaggerOperation(Summary = "Update an existing hotel record", Description = "Updates the hotel record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Hotel record updated successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<HotelResponse>> UpdateAsync([FromRoute] long id, [FromBody] HotelRequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a hotel record by its ID.
        /// </summary>
        /// <param name="id">The ID of the hotel record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteHotel/{id}")]
        [SwaggerOperation(Summary = "Delete a hotel record", Description = "Deletes the hotel record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Hotel record deleted successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Hotel record not found or failed to delete.")]
        public override Task<Response<HotelResponse>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }
    }
}
