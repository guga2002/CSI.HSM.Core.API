using Common.Data.Entities.Staff;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.staf;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class StaffController : CSIControllerBase<StaffDto, StaffResponseDto, long, Staffs>
{
    private readonly IStaffService _staffService;

    public StaffController(
        IStaffService staffService,
        IService<StaffDto, StaffResponseDto, long, Staffs> serviceProvider,
        IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _staffService = staffService;
    }

    [HttpGet("by-email")]
    [SwaggerOperation(Summary = "Retrieve Staff by Email", Description = "Fetches staff details by email.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Staff member retrieved successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<StaffResponseDto>> GetByEmailAsync([FromQuery] string email)
    {
        var result = await _staffService.GetByEmailAsync(email);
        return result != null
            ? Response<StaffResponseDto>.SuccessResponse(result)
            : Response<StaffResponseDto>.ErrorResponse("Staff member not found.");
    }

    [HttpGet("by-position")]
    [SwaggerOperation(Summary = "Retrieve Staff by Position", Description = "Fetches staff members by job position.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Staff members retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
    public async Task<Response<IEnumerable<StaffResponseDto>>> GetByPositionAsync([FromQuery] string position)
    {
        var result = await _staffService.GetByPositionAsync(position);
        return result.Any()
            ? Response<IEnumerable<StaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StaffResponseDto>>.ErrorResponse("No staff members found.");
    }

    [HttpGet("by-supervisor/{supervisorId:long}")]
    [SwaggerOperation(Summary = "Retrieve Staff by Supervisor ID", Description = "Fetches all staff members supervised by a specific supervisor.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Staff members retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
    public async Task<Response<IEnumerable<StaffResponseDto>>> GetBySupervisorIdAsync([FromRoute] long supervisorId)
    {
        var result = await _staffService.GetBySupervisorIdAsync(supervisorId);
        return result.Any()
            ? Response<IEnumerable<StaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StaffResponseDto>>.ErrorResponse("No staff members found.");
    }

    [HttpGet("hired-between")]
    [SwaggerOperation(Summary = "Retrieve Staff Hired Between Two Dates", Description = "Fetches staff members hired between two dates.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Staff members retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
    public async Task<Response<IEnumerable<StaffResponseDto>>> GetStaffHiredBetweenDatesAsync(
        [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var result = await _staffService.GetStaffHiredBetweenDatesAsync(startDate, endDate);
        return result.Any()
            ? Response<IEnumerable<StaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StaffResponseDto>>.ErrorResponse("No staff members found.");
    }

    [HttpGet("active")]
    [SwaggerOperation(Summary = "Retrieve Active Staff", Description = "Fetches all active staff members.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Active staff retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No active staff members found.")]
    public async Task<Response<IEnumerable<StaffResponseDto>>> GetActiveStaffAsync()
    {
        var result = await _staffService.GetActiveStaffAsync();
        return result.Any()
            ? Response<IEnumerable<StaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StaffResponseDto>>.ErrorResponse("No active staff members found.");
    }

    [HttpGet("inactive")]
    [SwaggerOperation(Summary = "Retrieve Inactive Staff", Description = "Fetches all inactive staff members.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Inactive staff retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No inactive staff members found.")]
    public async Task<Response<IEnumerable<StaffResponseDto>>> GetInactiveStaffAsync()
    {
        var result = await _staffService.GetInactiveStaffAsync();
        return result.Any()
            ? Response<IEnumerable<StaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<StaffResponseDto>>.ErrorResponse("No inactive staff members found.");
    }

    [HttpPatch("update-position/{staffId:long}")]
    [SwaggerOperation(Summary = "Update Staff Position", Description = "Updates the job position of a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Position updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<bool>> UpdatePositionAsync([FromRoute] long staffId, [FromBody] string newPosition)
    {
        var result = await _staffService.UpdatePositionAsync(staffId, newPosition);
        return result
            ? Response<bool>.SuccessResponse(true, "Position updated successfully.")
            : Response<bool>.ErrorResponse("Staff member not found.");
    }

    [HttpPatch("update-salary/{staffId:long}")]
    [SwaggerOperation(Summary = "Update Staff Salary", Description = "Updates the salary of a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Salary updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<bool>> UpdateSalaryAsync([FromRoute] long staffId, [FromBody] decimal newSalary)
    {
        var result = await _staffService.UpdateSalaryAsync(staffId, newSalary);
        return result
            ? Response<bool>.SuccessResponse(true, "Salary updated successfully.")
            : Response<bool>.ErrorResponse("Staff member not found.");
    }

    [HttpPatch("assign-supervisor/{staffId:long}")]
    [SwaggerOperation(Summary = "Assign Supervisor", Description = "Assigns a new supervisor to a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Supervisor assigned successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<bool>> AssignSupervisorAsync([FromRoute] long staffId, [FromBody] long newSupervisorId)
    {
        var result = await _staffService.AssignSupervisorAsync(staffId, newSupervisorId);
        return result
            ? Response<bool>.SuccessResponse(true, "Supervisor assigned successfully.")
            : Response<bool>.ErrorResponse("Staff member not found.");
    }

    [HttpPatch("checkIsOnDute/{staffId:long}")]
    [SwaggerOperation(Summary = "check isondute", Description = "check staffs check is on dute")]
    [SwaggerResponse(StatusCodes.Status200OK, "check is on dute successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<bool>> CheckIsOnDuteAsync(long staffId, bool Status, CancellationToken cancellationToken = default)
    {
        var result = await _staffService.CheckIsOnDuteAsync(staffId, Status, cancellationToken);
        return result
            ? Response<bool>.SuccessResponse(true, "Check is on dute successfully")
            : Response<bool>.ErrorResponse("Staff member not found.");
    }

    [HttpGet("getLastLoginDate/{staffId:long}")]
    [SwaggerOperation(
     Summary = "Get last login date for staff",
     Description = "Returns the last recorded login time for the specified staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Last login date retrieved successfully.", typeof(Response<StaffLoginDate>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Staff member not found.")]
    public async Task<Response<StaffLoginDate>> GetLastLoginDateAsync(long staffId, CancellationToken cancellationToken = default)
    {
        var result = await _staffService.GetLastLoginDateAsync(staffId, cancellationToken);

        return result != null
            ? Response<StaffLoginDate>.SuccessResponse(result)
            : Response<StaffLoginDate>.ErrorResponse("Staff is not found");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Staff Members", Description = "Returns all staff records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<StaffResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Staff Member by ID", Description = "Fetches a specific staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Staff Member", Description = "Adds a new staff record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffResponseDto>> CreateAsync([FromBody] StaffDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Staff Member", Description = "Updates an existing staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<StaffResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Staff Member", Description = "Deletes a staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<StaffResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Staff Members", Description = "Deletes multiple staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<StaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Staff Members", Description = "Updates multiple staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<StaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Staff Members", Description = "Adds multiple staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<StaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Staff Member", Description = "Marks a staff record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<StaffResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
