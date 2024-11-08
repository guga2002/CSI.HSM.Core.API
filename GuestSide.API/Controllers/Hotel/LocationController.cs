using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Hotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : CSIControllerBase<LocationrequestDto, LocationResponse, long, GuestSide.Core.Entities.Hotel.GeoLocation.Location>
    {
        private readonly ILocationService _locationService;
        public LocationController(IService<LocationrequestDto, LocationResponse, long, Location> serviceProvider, ILocationService locationService) : base(serviceProvider)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Retrieves all location records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all location records.</returns>
        [HttpGet("GetLocations")]
        [SwaggerOperation(Summary = "Retrieve all location records", Description = "Returns a list of all location records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved location records.", typeof(Response<IEnumerable<LocationResponse>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No location records found.")]
        public override Task<Response<IEnumerable<LocationResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific location record by its ID.
        /// </summary>
        /// <param name="id">The ID of the location record.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The location record matching the specified ID.</returns>
        [HttpGet("GetLocationById/{id}")]
        [SwaggerOperation(Summary = "Retrieve location record by ID", Description = "Returns a specific location record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the location record.", typeof(Response<LocationResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location record not found.")]
        public override Task<Response<LocationResponse>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new location record.
        /// </summary>
        /// <param name="entityDto">The location record to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created location record.</returns>
        [HttpPost("CreateLocation")]
        [SwaggerOperation(Summary = "Create a new location record", Description = "Creates a new location record.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Location record created successfully.", typeof(Response<LocationResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<LocationResponse>> CreateAsync([FromBody] LocationrequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing location record.
        /// </summary>
        /// <param name="id">The ID of the location record to update.</param>
        /// <param name="entityDto">The updated location record data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated location record.</returns>
        [HttpPut("UpdateLocation/{id}")]
        [SwaggerOperation(Summary = "Update an existing location record", Description = "Updates the location record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Location record updated successfully.", typeof(Response<LocationResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<LocationResponse>> UpdateAsync([FromRoute] long id, [FromBody] LocationrequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a location record by its ID.
        /// </summary>
        /// <param name="id">The ID of the location record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteLocation/{id}")]
        [SwaggerOperation(Summary = "Delete a location record", Description = "Deletes the location record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Location record deleted successfully.", typeof(Response<LocationResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location record not found or failed to delete.")]
        public override Task<Response<LocationResponse>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Get location by hotel ID.
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        ///  [HttpDelete("DeleteLocation/{id}")]
        [SwaggerOperation(Summary = "Get a location record by hotel Id", Description = "you must pass hotel id and  this endpoint will return location of this hotel")]
        [SwaggerResponse(StatusCodes.Status200OK, "get location  for  hotel", typeof(Response<LocationResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Location record not found or failed to retrive data.")]
        [HttpGet("GetLocationByHotelId/{hotelId:long}")]
        public async Task<LocationResponse> GetLocationByHotelId(long hotelId, CancellationToken token = default)
        {
            if(hotelId <= 0)
            {
                throw new ArgumentException("Invalid hotel ID.");
            }

            return await _locationService.GetLocationByHotelId(hotelId, token);
        }
    }
}
