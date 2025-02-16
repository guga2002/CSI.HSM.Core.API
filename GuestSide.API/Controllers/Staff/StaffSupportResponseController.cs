using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff;
using Core.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffSupportResponseController : CSIControllerBase<StaffSupportResponseDto, StaffSupportResponseResponseDto, long, StaffSupportResponse>
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
    }
}
