using Common.Data.Entities.Staff;
using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.StaffSupportResponse;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class StaffSupportResponseController : CSIControllerBase<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, StaffSupportResponse>
{
    private readonly IStaffSupportResponseService _staffSupportResponseService;

    public StaffSupportResponseController(
        IStaffSupportResponseService staffSupportResponseService)
        : base(staffSupportResponseService, staffSupportResponseService)
    {
        _staffSupportResponseService = staffSupportResponseService;
    }

    /// <summary>
    /// Retrieve all support responses for a specific ticket.
    /// </summary>
    [HttpGet("ticket/{ticketId:long}")]
    [SwaggerOperation(Summary = "Get Responses by Ticket ID", Description = "Fetches all support responses associated with a specific support ticket.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Responses retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No responses found.")]
    public async Task<Response<IEnumerable<StaffSupportResponseResponseDto>>> GetResponsesByTicketIdAsync([FromRoute] long ticketId, CancellationToken cancellationToken = default)
    {
        var responses = await _staffSupportResponseService.GetResponsesByTicketIdAsync(ticketId, cancellationToken);
        return responses.Any()
            ? Response<IEnumerable<StaffSupportResponseResponseDto>>.SuccessResponse(responses)
            : Response<IEnumerable<StaffSupportResponseResponseDto>>.ErrorResponse("No responses found for the given ticket.");
    }

    /// <summary>
    /// Retrieve all support team responses.
    /// </summary>
    [HttpGet("support-team/{isFromSupportTeam:bool}")]
    [SwaggerOperation(Summary = "Get Support Team Responses", Description = "Fetches all responses sent by the support team.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Responses retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No responses found.")]
    public async Task<Response<IEnumerable<StaffSupportResponseResponseDto>>> GetSupportTeamResponsesAsync([FromRoute] bool isFromSupportTeam, CancellationToken cancellationToken = default)
    {
        var responses = await _staffSupportResponseService.GetSupportTeamResponsesAsync(isFromSupportTeam, cancellationToken);
        return responses.Any()
            ? Response<IEnumerable<StaffSupportResponseResponseDto>>.SuccessResponse(responses)
            : Response<IEnumerable<StaffSupportResponseResponseDto>>.ErrorResponse("No support team responses found.");
    }

    /// <summary>
    /// Retrieve all responses made within the last N days.
    /// </summary>
    [HttpGet("recent/{days:int}")]
    [SwaggerOperation(Summary = "Get Recent Responses", Description = "Fetches all responses made within the last N days.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Responses retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No recent responses found.")]
    public async Task<Response<IEnumerable<StaffSupportResponseResponseDto>>> GetRecentResponsesAsync([FromRoute] int days, CancellationToken cancellationToken = default)
    {
        var responses = await _staffSupportResponseService.GetRecentResponsesAsync(days, cancellationToken);
        return responses.Any()
            ? Response<IEnumerable<StaffSupportResponseResponseDto>>.SuccessResponse(responses)
            : Response<IEnumerable<StaffSupportResponseResponseDto>>.ErrorResponse("No recent responses found.");
    }

    /// <summary>
    /// Update a response message.
    /// </summary>
    [HttpPut("update-message/{responseId:long}")]
    [SwaggerOperation(Summary = "Update Response Message", Description = "Updates the message of a specific support response.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Response updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> UpdateResponseMessageAsync([FromRoute] long responseId, [FromBody] string newMessage, CancellationToken cancellationToken = default)
    {
        var result = await _staffSupportResponseService.UpdateResponseMessageAsync(responseId, newMessage, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to update response message.");
    }

    /// <summary>
    /// Add attachments to a support response.
    /// </summary>
    [HttpPost("add-attachments/{responseId:long}")]
    [SwaggerOperation(Summary = "Add Attachments to Response", Description = "Adds one or more attachments to a specific support response.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Attachments added successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> AddAttachmentToResponseAsync([FromRoute] long responseId, [FromBody] List<string> attachments, CancellationToken cancellationToken = default)
    {
        var result = await _staffSupportResponseService.AddAttachmentToResponseAsync(responseId, attachments, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to add attachments.");
    }

    /// <summary>
    /// Mark a response as from the support team.
    /// </summary>
    [HttpPatch("mark-as-support/{responseId:long}")]
    [SwaggerOperation(Summary = "Mark Response as Support Team", Description = "Marks a specific response as being from the support team.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Response marked successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
    public async Task<Response<bool>> MarkResponseAsSupportTeamAsync([FromRoute] long responseId, [FromBody] bool isFromSupportTeam, CancellationToken cancellationToken = default)
    {
        var result = await _staffSupportResponseService.MarkResponseAsSupportTeamAsync(responseId, isFromSupportTeam, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(result)
            : Response<bool>.ErrorResponse("Failed to mark response as support team.");
    }

    /// <summary>
    /// Count the number of responses per ticket.
    /// </summary>
    [HttpGet("count-responses/{ticketId:long}")]
    [SwaggerOperation(Summary = "Count Responses per Ticket", Description = "Counts the number of responses associated with a specific ticket.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No responses found.")]
    public async Task<Response<int>> CountResponsesPerTicketAsync([FromRoute] long ticketId, CancellationToken cancellationToken = default)
    {
        var count = await _staffSupportResponseService.CountResponsesPerTicketAsync(ticketId, cancellationToken);
        return count > 0
            ? Response<int>.SuccessResponse(count)
            : Response<int>.ErrorResponse("No responses found for the given ticket.");
    }

    /// <summary>
    /// Count the total number of support team responses.
    /// </summary>
    [HttpGet("count-support-responses")]
    [SwaggerOperation(Summary = "Count Support Team Responses", Description = "Counts the total number of responses made by the support team.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No support responses found.")]
    public async Task<Response<int>> CountSupportTeamResponsesAsync(CancellationToken cancellationToken = default)
    {
        var count = await _staffSupportResponseService.CountSupportTeamResponsesAsync(cancellationToken);
        return count > 0
            ? Response<int>.SuccessResponse(count)
            : Response<int>.ErrorResponse("No support team responses found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<StaffSupportResponseResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffSupportResponseResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffSupportResponseResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Guest record", Description = "Adds a new guest record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffSupportResponseResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffSupportResponseResponseDto>> CreateAsync([FromBody] StaffSupportResponseRequestDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffSupportResponseResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffSupportResponseResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffSupportResponseRequestDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Guest record", Description = "Deletes a guest record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffSupportResponseResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<StaffSupportResponseResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:int}")]
    [SwaggerOperation(Summary = "Soft delete a Guest record", Description = "Marks a guest record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffSupportResponseResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffSupportResponseResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }

}
