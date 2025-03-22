using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Item;
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
    public class StaffIncidentController : CSIControllerBase<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>
    {
        private readonly IStaffIncidentService _staffIncidentService;

        public StaffIncidentController(IStaffIncidentService staffIncidentService)
            : base(staffIncidentService, staffIncidentService)
        {
            _staffIncidentService = staffIncidentService;
        }

        ///// <summary>
        ///// Retrieve all incidents related to a specific staff member.
        ///// </summary>
        //[HttpGet("IncidentsByStaffId/{staffId:long}")]
        //[SwaggerOperation(Summary = "Get Incidents by Staff ID", Description = "Fetches all incident reports related to a specific staff member.")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Incidents retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No incident records found.")]
        //public async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetIncidentsByStaffIdAsync([FromRoute] long staffId, CancellationToken cancellationToken = default)
        //{
        //    var incidents = await _staffIncidentService.GetIncidentsByStaffIdAsync(staffId, cancellationToken);
        //    return incidents.Any()
        //        ? Response<IEnumerable<StaffIncidentResponseDto>>.SuccessResponse(incidents)
        //        : Response<IEnumerable<StaffIncidentResponseDto>>.ErrorResponse("No incident records found for the specified staff ID.");
        //}

        ///// <summary>
        ///// Retrieve incidents filtered by severity level.
        ///// </summary>
        //[HttpGet("severity/{severity}")]
        //[SwaggerOperation(Summary = "Get Incidents by Severity", Description = "Fetches incidents filtered by severity level (e.g., Low, Medium, High).")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Incidents retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No incidents found.")]
        //public async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetIncidentsBySeverityAsync([FromRoute] string severity, CancellationToken cancellationToken = default)
        //{
        //    var incidents = await _staffIncidentService.GetIncidentsBySeverityAsync(severity, cancellationToken);
        //    return incidents.Any()
        //        ? Response<IEnumerable<StaffIncidentResponseDto>>.SuccessResponse(incidents)
        //        : Response<IEnumerable<StaffIncidentResponseDto>>.ErrorResponse("No incidents found for the specified severity level.");
        //}

        ////<summary>
        //// Retrieve incidents filtered by status.
        //// </summary>
        [HttpGet("status/{status}")]
        [SwaggerOperation(Summary = "Get Incidents by Status", Description = "Fetches incidents filtered by status (e.g., Open, In Progress, Resolved).")]
        [SwaggerResponse(StatusCodes.Status200OK, "Incidents retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No incidents found.")]
        public async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetIncidentsByStatusAsync([FromRoute] string status, CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentService.GetIncidentsByStatusAsync(status, cancellationToken);
            return incidents.Any()
                ? Response<IEnumerable<StaffIncidentResponseDto>>.SuccessResponse(incidents)
                : Response<IEnumerable<StaffIncidentResponseDto>>.ErrorResponse("No incidents found for the specified status.");
        }

        /// <summary>
        /// Retrieve incidents filtered by type.
        /// </summary>
        //[HttpGet("type/{incidentType}")]
        //[SwaggerOperation(Summary = "Get Incidents by Type", Description = "Fetches incidents filtered by type (e.g., Policy Violation, Harassment, Safety Issue).")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Incidents retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No incidents found.")]
        //public async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetIncidentsByTypeAsync([FromRoute] string incidentType, CancellationToken cancellationToken = default)
        //{
        //    var incidents = await _staffIncidentService.GetIncidentsByTypeAsync(incidentType, cancellationToken);
        //    return incidents.Any()
        //        ? Response<IEnumerable<StaffIncidentResponseDto>>.SuccessResponse(incidents)
        //        : Response<IEnumerable<StaffIncidentResponseDto>>.ErrorResponse("No incidents found for the specified type.");
        //}

        /// <summary>
        /// Retrieve all urgent incidents.
        /// </summary>
        //[HttpGet("urgent")]
        //[SwaggerOperation(Summary = "Get Urgent Incidents", Description = "Fetches all incidents classified as urgent.")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Urgent incidents retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No urgent incidents found.")]
        //public async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default)
        //{
        //    var incidents = await _staffIncidentService.GetUrgentIncidentsAsync(cancellationToken);
        //    return incidents.Any()
        //        ? Response<IEnumerable<StaffIncidentResponseDto>>.SuccessResponse(incidents)
        //        : Response<IEnumerable<StaffIncidentResponseDto>>.ErrorResponse("No urgent incidents found.");
        //}

        /// <summary>
        /// Update the status of an incident.
        /// </summary>
        [HttpPut("update-status/{incidentId:long}")]
        [SwaggerOperation(Summary = "Update Incident Status", Description = "Updates the status of a specific incident.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Incident status updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        public async Task<Response<bool>> UpdateIncidentStatusAsync([FromRoute] long incidentId, [FromBody] string newStatus, CancellationToken cancellationToken = default)
        {
            var result = await _staffIncidentService.UpdateIncidentStatusAsync(incidentId, newStatus, cancellationToken);
            return result
                ? Response<bool>.SuccessResponse(result)
                : Response<bool>.ErrorResponse("Failed to update incident status.");
        }

        /// <summary>
        /// Resolve an incident with resolution notes.
        /// </summary>
        [HttpPut("resolve/{incidentId:long}")]
        [SwaggerOperation(Summary = "Resolve Incident", Description = "Marks an incident as resolved and provides resolution notes.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Incident resolved successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        public async Task<Response<bool>> ResolveIncidentAsync([FromRoute] long incidentId, [FromBody] string resolutionNotes, CancellationToken cancellationToken = default)
        {
            var result = await _staffIncidentService.ResolveIncidentAsync(incidentId, resolutionNotes, cancellationToken);
            return result
                ? Response<bool>.SuccessResponse(result)
                : Response<bool>.ErrorResponse("Failed to resolve incident.");
        }

        /// <summary>
        /// Count all open incidents.
        /// </summary>
        [HttpGet("count/open")]
        [SwaggerOperation(Summary = "Count Open Incidents", Description = "Retrieves the total number of open incidents.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Open incidents count retrieved successfully.", typeof(Response<int>))]
        public async Task<Response<int>> CountOpenIncidentsAsync(CancellationToken cancellationToken = default)
        {
            var count = await _staffIncidentService.CountOpenIncidentsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        /// <summary>
        /// Count all resolved incidents.
        /// </summary>
        [HttpGet("count/resolved")]
        [SwaggerOperation(Summary = "Count Resolved Incidents", Description = "Retrieves the total number of resolved incidents.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Resolved incidents count retrieved successfully.", typeof(Response<int>))]
        public async Task<Response<int>> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default)
        {
            var count = await _staffIncidentService.CountResolvedIncidentsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        /// <summary>
        /// Count all urgent incidents.
        /// </summary>
        [HttpGet("count/urgent")]
        [SwaggerOperation(Summary = "Count Urgent Incidents", Description = "Retrieves the total number of urgent incidents.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Urgent incidents count retrieved successfully.", typeof(Response<int>))]
        public async Task<Response<int>> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default)
        {
            var count = await _staffIncidentService.CountUrgentIncidentsAsync(cancellationToken);
            return Response<int>.SuccessResponse(count);
        }

        [HttpPost("CreteIncident")]
        public override Task<Response<StaffIncidentResponseDto>> CreateAsync([FromBody]StaffIncidentDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Guests", Description = "Returns all guest records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffIncidentResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<StaffIncidentResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Retrieve a Guest by ID", Description = "Fetches a specific guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffIncidentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<StaffIncidentResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }


        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Update an existing Guest record", Description = "Updates an existing guest record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffInfoAboutRanOutItemsResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<StaffIncidentResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffIncidentDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }
    }
}
