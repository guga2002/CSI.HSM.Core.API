using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Enums;
using Core.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class StaffInfoAboutRanOutItemsController : CSIControllerBase<
    StaffInfoAboutRanOutItemsDto,
    StaffInfoAboutRanOutItemsResponseDto,
    long,
    StaffInfoAboutRanOutItems>
{
    private readonly IStaffInfoAboutRanOutItemsService _ranOutItemsService;

    public StaffInfoAboutRanOutItemsController(
        IStaffInfoAboutRanOutItemsService ranOutItemsService)
        : base(ranOutItemsService, ranOutItemsService)
    {
        _ranOutItemsService = ranOutItemsService;
    }

    /// <summary>
    /// Retrieve all refill requests made by a specific staff member.
    /// </summary>
    [HttpGet("staff/{staffId:long}")]
    [SwaggerOperation(Summary = "Get Refill Requests by Staff ID", Description = "Fetches all refill requests submitted by a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Requests retrieved successfully.", typeof(Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No requests found.")]
    public async Task<Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>> GetRequestsByStaffIdAsync([FromRoute] long staffId, CancellationToken cancellationToken = default)
    {
        var requests = await _ranOutItemsService.GetRequestsByStaffIdAsync(staffId, cancellationToken);
        return requests.Any()
            ? Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.SuccessResponse(requests)
            : Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.ErrorResponse("No refill requests found for the specified staff ID.");
    }

    /// <summary>
    /// Retrieve refill requests filtered by priority.
    /// </summary>
    [HttpGet("priority/{priority}")]
    [SwaggerOperation(Summary = "Get Refill Requests by Priority", Description = "Fetches refill requests based on priority level (e.g., Low, Medium, High).")]
    [SwaggerResponse(StatusCodes.Status200OK, "Requests retrieved successfully.", typeof(Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No requests found.")]
    public async Task<Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>> GetRequestsByPriorityAsync([FromRoute] PriorityEnum priority, CancellationToken cancellationToken = default)
    {
        var requests = await _ranOutItemsService.GetRequestsByPriorityAsync(priority, cancellationToken);
        return requests.Any()
            ? Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.SuccessResponse(requests)
            : Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.ErrorResponse("No requests found for the specified priority level.");
    }

    /// <summary>
    /// Retrieve all unresolved refill requests.
    /// </summary>
    [HttpGet("unresolved")]
    [SwaggerOperation(Summary = "Get Unresolved Refill Requests", Description = "Fetches all unresolved refill requests.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Requests retrieved successfully.", typeof(Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No unresolved requests found.")]
    public async Task<Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>> GetUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
    {
        var requests = await _ranOutItemsService.GetUnresolvedRequestsAsync(cancellationToken);
        return requests.Any()
            ? Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.SuccessResponse(requests)
            : Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.ErrorResponse("No unresolved refill requests found.");
    }

    /// <summary>
    /// Retrieve urgent refill requests.
    /// </summary>
    [HttpGet("urgent")]
    [SwaggerOperation(Summary = "Get Urgent Refill Requests", Description = "Fetches all urgent refill requests.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Requests retrieved successfully.", typeof(Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No urgent requests found.")]
    public async Task<Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default)
    {
        var requests = await _ranOutItemsService.GetUrgentRequestsAsync(cancellationToken);
        return requests.Any()
            ? Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.SuccessResponse(requests)
            : Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>.ErrorResponse("No urgent refill requests found.");
    }

    /// <summary>
    /// Mark a refill request as resolved.
    /// </summary>
    [HttpPut("resolve/{requestId:long}")]
    [SwaggerOperation(Summary = "Resolve Refill Request", Description = "Marks a refill request as resolved with optional resolution notes.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request resolved successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> MarkRequestResolvedAsync([FromRoute] long requestId, [FromBody] string? notes, CancellationToken cancellationToken = default)
    {
        var result = await _ranOutItemsService.MarkRequestResolvedAsync(requestId, notes, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to mark request as resolved.");
    }

    /// <summary>
    /// Count all unresolved refill requests.
    /// </summary>
    [HttpGet("count/unresolved")]
    [SwaggerOperation(Summary = "Count Unresolved Refill Requests", Description = "Retrieves the total number of unresolved refill requests.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    public async Task<Response<int>> CountUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
    {
        var count = await _ranOutItemsService.CountUnresolvedRequestsAsync(cancellationToken);
        return Response<int>.SuccessResponse(count);
    }

    /// <summary>
    /// Count all high-priority refill requests.
    /// </summary>
    [HttpGet("count/high-priority")]
    [SwaggerOperation(Summary = "Count High-Priority Refill Requests", Description = "Retrieves the total number of high-priority refill requests.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    public async Task<Response<int>> CountHighPriorityRequestsAsync(CancellationToken cancellationToken = default)
    {
        var count = await _ranOutItemsService.CountHighPriorityRequestsAsync(cancellationToken);
        return Response<int>.SuccessResponse(count);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffInfoAboutRanOutItemsResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Guest record", Description = "Adds a new guest record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffInfoAboutRanOutItemsResponseDto>> CreateAsync([FromBody] StaffInfoAboutRanOutItemsDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffInfoAboutRanOutItemsResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffInfoAboutRanOutItemsDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Guest record", Description = "Deletes a guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<StaffInfoAboutRanOutItemsResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }  

    [HttpPatch("soft-delete/{id:int}")]
    [SwaggerOperation(Summary = "Soft delete a Guest record", Description = "Marks a guest record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffInfoAboutRanOutItemsResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
