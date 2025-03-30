using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Hotel;

[Route("api/[controller]")]
[ApiController]
public class LocationController : CSIControllerBase<LocationrequestDto, LocationResponse, long, Location>
{
    private readonly ILocationService _locationService;

    public LocationController(
        ILocationService locationService,
        IService<LocationrequestDto, LocationResponse, long, Location> serviceProvider,
        IAdditionalFeatures<LocationrequestDto, LocationResponse, long, Location> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _locationService = locationService;
    }

    [HttpGet("by-hotel/{hotelId:long}")]
    [SwaggerOperation(Summary = "Retrieve location by hotel ID", Description = "Fetches the location details of a hotel by its ID.")]
    [ProducesResponseType(typeof(Response<LocationResponse>), StatusCodes.Status200OK)]
    public async Task<Response<LocationResponse?>> GetLocationByHotelId([FromRoute] long hotelId, CancellationToken cancellationToken = default)
    {
        var result = await _locationService.GetLocationByHotelId(hotelId, cancellationToken);
        return new Response<LocationResponse?>(result is not null ? true : false, result);
    }

    [HttpGet("nearest-hotel")]
    [SwaggerOperation(Summary = "Find the nearest hotel", Description = "Finds the nearest hotel based on given latitude and longitude.")]
    [ProducesResponseType(typeof(Response<LocationResponse>), StatusCodes.Status200OK)]
    public async Task<Response<LocationResponse?>> FindNearestHotel([FromQuery] double latitude, [FromQuery] double longitude, CancellationToken cancellationToken = default)
    {
        var result = await _locationService.FindNearestHotel(latitude, longitude, cancellationToken);
        return new Response<LocationResponse?>(result is not null ? true : false, result);
    }

    [HttpPut("update-location/{hotelId:long}")]
    [SwaggerOperation(Summary = "Update hotel location", Description = "Updates the latitude and longitude of a hotel location.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> UpdateHotelLocation([FromRoute] long hotelId, [FromBody] LocationrequestDto locationDto, CancellationToken cancellationToken = default)
    {
        var result = await _locationService.UpdateHotelLocation(hotelId, locationDto.Latitude, locationDto.Longitude, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Locations", Description = "Returns all location records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<LocationResponse>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<LocationResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Location by ID", Description = "Fetches a specific location record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<LocationResponse>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Location record", Description = "Adds a new location record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<LocationResponse>> CreateAsync([FromBody] LocationrequestDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Location record", Description = "Updates an existing location record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<LocationResponse>> UpdateAsync([FromRoute] long id, [FromBody] LocationrequestDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Location record", Description = "Deletes a location record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<LocationResponse>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Location records", Description = "Deletes multiple location records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<LocationrequestDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Location records", Description = "Updates multiple location records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<LocationrequestDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Location records", Description = "Adds multiple location records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<LocationrequestDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Location record", Description = "Marks a location record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<LocationResponse>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<LocationResponse>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
