using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Item;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff;
using Core.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffSupportController : CSIControllerBase<StaffSupportDto, StaffSupportResponseDto, long, StaffSupport>
    {
        private readonly IStaffSupportService _staffSupportService;

        public StaffSupportController(
            IStaffSupportService staffSupportService)
            : base(staffSupportService, staffSupportService)
        {
            _staffSupportService = staffSupportService;
        }

        /// <summary>
        /// Retrieve all support tickets for a specific staff member.
        /// </summary>
        [HttpGet("staff/{staffId:long}")]
        [SwaggerOperation(Summary = "Get Support Tickets by Staff ID", Description = "Fetches all support tickets associated with a specific staff member.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tickets retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tickets found.")]
        public async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetTicketsByStaffIdAsync([FromRoute] long staffId, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportService.GetTicketsByStaffIdAsync(staffId, cancellationToken);
            return tickets.Any()
                ? Response<IEnumerable<StaffSupportResponseDto>>.SuccessResponse(tickets)
                : Response<IEnumerable<StaffSupportResponseDto>>.ErrorResponse("No support tickets found for the given staff ID.");
        }

        /// <summary>
        /// Retrieve support tickets by priority level.
        /// </summary>
        [HttpGet("priority/{priority}")]
        [SwaggerOperation(Summary = "Get Support Tickets by Priority", Description = "Fetches all support tickets filtered by priority.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tickets retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tickets found.")]
        public async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetTicketsByPriorityAsync([FromRoute] SupportTicketPriority priority, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportService.GetTicketsByPriorityAsync(priority, cancellationToken);
            return tickets.Any()
                ? Response<IEnumerable<StaffSupportResponseDto>>.SuccessResponse(tickets)
                : Response<IEnumerable<StaffSupportResponseDto>>.ErrorResponse("No tickets found for the specified priority.");
        }

        /// <summary>
        /// Retrieve support tickets by status.
        /// </summary>
        [HttpGet("status/{status}")]
        [SwaggerOperation(Summary = "Get Support Tickets by Status", Description = "Fetches all support tickets filtered by status.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tickets retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tickets found.")]
        public async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetTicketsByStatusAsync([FromRoute] SupportTicketStatus status, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportService.GetTicketsByStatusAsync(status, cancellationToken);
            return tickets.Any()
                ? Response<IEnumerable<StaffSupportResponseDto>>.SuccessResponse(tickets)
                : Response<IEnumerable<StaffSupportResponseDto>>.ErrorResponse("No tickets found for the specified status.");
        }

        /// <summary>
        /// Retrieve support tickets by category.
        /// </summary>
        [HttpGet("category/{category}")]
        [SwaggerOperation(Summary = "Get Support Tickets by Category", Description = "Fetches all support tickets filtered by category.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tickets retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tickets found.")]
        public async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetTicketsByCategoryAsync([FromRoute] string category, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportService.GetTicketsByCategoryAsync(category, cancellationToken);
            return tickets.Any()
                ? Response<IEnumerable<StaffSupportResponseDto>>.SuccessResponse(tickets)
                : Response<IEnumerable<StaffSupportResponseDto>>.ErrorResponse("No tickets found for the specified category.");
        }

        /// <summary>
        /// Retrieve support tickets created within the last N days.
        /// </summary>
        [HttpGet("recent/{days:int}")]
        [SwaggerOperation(Summary = "Get Recent Support Tickets", Description = "Fetches all support tickets created within the last N days.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tickets retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No recent tickets found.")]
        public async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetRecentTicketsAsync([FromRoute] int days, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportService.GetRecentTicketsAsync(days, cancellationToken);
            return tickets.Any()
                ? Response<IEnumerable<StaffSupportResponseDto>>.SuccessResponse(tickets)
                : Response<IEnumerable<StaffSupportResponseDto>>.ErrorResponse("No recent tickets found.");
        }

        /// <summary>
        /// Update the status of a support ticket.
        /// </summary>
        [HttpPut("update-status/{ticketId:long}")]
        [SwaggerOperation(Summary = "Update Ticket Status", Description = "Updates the status of a specific support ticket.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket status updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        public async Task<Response<bool>> UpdateTicketStatusAsync([FromRoute] long ticketId, [FromBody] SupportTicketStatus newStatus, CancellationToken cancellationToken = default)
        {
            var result = await _staffSupportService.UpdateTicketStatusAsync(ticketId, newStatus, cancellationToken);
            return result
                ? Response<bool>.SuccessResponse(result)
                : Response<bool>.ErrorResponse("Failed to update ticket status.");
        }

        /// <summary>
        /// Resolve a support ticket.
        /// </summary>
        [HttpPatch("resolve/{ticketId:long}")]
        [SwaggerOperation(Summary = "Resolve Support Ticket", Description = "Marks a support ticket as resolved with resolution notes.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Ticket resolved successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        public async Task<Response<bool>> ResolveTicketAsync([FromRoute] long ticketId, [FromBody] string resolutionNotes, CancellationToken cancellationToken = default)
        {
            var result = await _staffSupportService.ResolveTicketAsync(ticketId, resolutionNotes, cancellationToken);
            return result
                ? Response<bool>.SuccessResponse(result)
                : Response<bool>.ErrorResponse("Failed to resolve ticket.");
        }

        /// <summary>
        /// Retrieve count of open support tickets.
        /// </summary>
        [HttpGet("count/open")]
        [SwaggerOperation(Summary = "Count Open Tickets", Description = "Counts the number of open support tickets.")]
        public async Task<Response<int>> CountOpenTicketsAsync(CancellationToken cancellationToken = default)
        {
            int count = await _staffSupportService.CountOpenTicketsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        /// <summary>
        /// Retrieve count of resolved support tickets.
        /// </summary>
        [HttpGet("count/resolved")]
        [SwaggerOperation(Summary = "Count Resolved Tickets", Description = "Counts the number of resolved support tickets.")]
        public async Task<Response<int>> CountResolvedTicketsAsync(CancellationToken cancellationToken = default)
        {
            int count = await _staffSupportService.CountResolvedTicketsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        /// <summary>
        /// Retrieve count of high-priority support tickets.
        /// </summary>
        [HttpGet("count/high-priority")]
        [SwaggerOperation(Summary = "Count High-Priority Tickets", Description = "Counts the number of high-priority support tickets.")]
        public async Task<Response<int>> CountHighPriorityTicketsAsync(CancellationToken cancellationToken = default)
        {
            int count = await _staffSupportService.CountHighPriorityTicketsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffSupportResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<StaffSupportResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffSupportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<StaffSupportResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Guest record", Description = "Adds a new guest record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffSupportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<StaffSupportResponseDto>> CreateAsync([FromBody] StaffSupportDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffSupportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<StaffSupportResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffSupportDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Delete a Guest record", Description = "Deletes a guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffSupportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<StaffSupportResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:int}")]
        [SwaggerOperation(Summary = "Soft delete a Guest record", Description = "Marks a guest record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffSupportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<StaffSupportResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
