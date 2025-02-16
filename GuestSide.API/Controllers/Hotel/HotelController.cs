using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Hotel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Hotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : CSIControllerBase<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>
    {
        private readonly IHotelService _hotelService;
        public HotelController(
            IHotelService hotelService,
            IService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel> serviceProvider,
            IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _hotelService = hotelService;
        }

        [HttpGet("by-city/{city}")]
        [SwaggerOperation(Summary = "Retrieve hotels by city", Description = "Returns a list of hotels located in a specific city.")]
        [ProducesResponseType(typeof(Response<IEnumerable<HotelResponse>>), StatusCodes.Status200OK)]
        public async Task<Response<IEnumerable<HotelResponse>>> GetHotelsByCity([FromRoute] string city, CancellationToken cancellationToken = default)
        {
            var result = await _hotelService.GetHotelsByCity(city, cancellationToken);
            return new Response<IEnumerable<HotelResponse>>(true,result);
        }

        [HttpGet("by-stars/{stars:int}")]
        [SwaggerOperation(Summary = "Retrieve hotels by star rating", Description = "Returns a list of hotels with a specific star rating (1-5 stars).")]
        [ProducesResponseType(typeof(Response<IEnumerable<HotelResponse>>), StatusCodes.Status200OK)]
        public async Task<Response<IEnumerable<HotelResponse>>> GetHotelsByStars([FromRoute] int stars, CancellationToken cancellationToken = default)
        {
            var result = await _hotelService.GetHotelsByStars(stars, cancellationToken);
            return new Response<IEnumerable<HotelResponse>>(true, result);
        }

        [HttpGet("full-details/{hotelId:long}")]
        [SwaggerOperation(Summary = "Retrieve full hotel details", Description = "Returns detailed information about a hotel, including rooms and services.")]
        [ProducesResponseType(typeof(Response<HotelResponse>), StatusCodes.Status200OK)]
        public async Task<Response<HotelResponse?>> GetFullHotelDetails([FromRoute] long hotelId, CancellationToken cancellationToken = default)
        {
            var result = await _hotelService.GetFullHotelDetails(hotelId, cancellationToken);
            return new Response<HotelResponse?>(true, result);
        }

        [HttpPut("update-details/{hotelId:long}")]
        [SwaggerOperation(Summary = "Update hotel details", Description = "Updates hotel details, including address, description, pictures, and facilities.")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> UpdateHotelDetails([FromRoute] long hotelId, [FromBody] HotelRequestDto updateDto, CancellationToken cancellationToken = default)
        {
            var result = await _hotelService.UpdateHotelDetails(
                hotelId, updateDto.Address, updateDto.Description, updateDto.Pictures, updateDto.Facilities, cancellationToken);
            return new Response<bool>(true, result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Hotels", Description = "Returns all hotel records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<HotelResponse>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<HotelResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Hotel by ID", Description = "Fetches a specific hotel record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<HotelResponse>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Hotel record", Description = "Adds a new hotel record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<HotelResponse>> CreateAsync([FromBody] HotelRequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Hotel record", Description = "Updates an existing hotel record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<HotelResponse>> UpdateAsync([FromRoute] long id, [FromBody] HotelRequestDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Hotel record", Description = "Deletes a hotel record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<HotelResponse>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Hotel records", Description = "Deletes multiple hotel records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<HotelRequestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Hotel records", Description = "Updates multiple hotel records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<HotelRequestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Hotel records", Description = "Adds multiple hotel records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<HotelRequestDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Hotel record", Description = "Marks a hotel record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<HotelResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<HotelResponse>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
