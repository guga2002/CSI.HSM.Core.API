using Common.Data.Entities.Staff;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.Task;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff;

[Route("api/[controller]")]
[ApiController]
public class TaskToStaffController : CSIControllerBase<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>
{
    private readonly ITaskToStaffService _taskToStaffService;

    public TaskToStaffController(
        IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> serviceProvider,
        IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> additionalFeatures,
        ITaskToStaffService taskToStaffService)
        : base(serviceProvider, additionalFeatures)
    {
        _taskToStaffService = taskToStaffService;
    }

    [HttpGet("by-task/{taskId:long}")]
    [SwaggerOperation(Summary = "Retrieve a Task assigned to Staff by Task ID", Description = "Fetches a specific task assigned to staff.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public async Task<Response<TaskToStaffResponseDto>> GetByTaskIdAsync([FromRoute] long taskId)
    {
        var result = await _taskToStaffService.GetByTaskIdAsync(taskId);
        return result != null
            ? Response<TaskToStaffResponseDto>.SuccessResponse(result)
            : Response<TaskToStaffResponseDto>.ErrorResponse("No data found.");
    }

    [HttpGet("by-staff/{staffId:long}")]
    [SwaggerOperation(Summary = "Retrieve Tasks assigned to a Staff Member", Description = "Fetches all tasks assigned to a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskToStaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
    public async Task<Response<IEnumerable<TaskToStaffResponseDto>>> GetTasksByStaffIdAsync([FromRoute] long staffId)
    {
        var result = await _taskToStaffService.GetTasksByStaffIdAsync(staffId);
        return result.Any()
            ? Response<IEnumerable<TaskToStaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<TaskToStaffResponseDto>>.ErrorResponse("No tasks found.");
    }

    [HttpPatch("update-task-status/{taskId:long}")]
    [SwaggerOperation(Summary = "Update Task Status", Description = "Updates the status of a task assigned to staff.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task status updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
    public async Task<Response<bool>> UpdateTaskStatusAsync([FromRoute] long taskId, [FromBody] long statusId)
    {
        var result = await _taskToStaffService.UpdateTaskStatusAsync(taskId, statusId);
        return result
            ? Response<bool>.SuccessResponse(true, "Task status updated successfully.")
            : Response<bool>.ErrorResponse("Task not found.");
    }

    [HttpPatch("mark-completed/{taskId:long}")]
    [SwaggerOperation(Summary = "Mark Task as Completed", Description = "Marks a task assigned to staff as completed.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task marked as completed successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
    public async Task<Response<bool>> MarkTaskAsCompletedAsync([FromRoute] long taskId)
    {
        var result = await _taskToStaffService.MarkTaskAsCompletedAsync(taskId);
        return result
            ? Response<bool>.SuccessResponse(true, "Task marked as completed successfully.")
            : Response<bool>.ErrorResponse("Task not found.");
    }

    [HttpPost("assign-task/{taskId:long}/{staffId:long}")]
    [SwaggerOperation(Summary = "Assign Task to Staff", Description = "Assigns a task to a staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task assigned successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    public async Task<Response<bool>> AssignTaskToStaffAsync([FromRoute] long taskId, [FromRoute] long staffId)
    {
        var result = await _taskToStaffService.AssignTaskToStaffAsync(taskId, staffId);
        return result
            ? Response<bool>.SuccessResponse(true, "Task assigned successfully.")
            : Response<bool>.ErrorResponse("Failed to assign task.");
    }

    [HttpGet("active-tasks/{staffId:long}")]
    [SwaggerOperation(Summary = "Retrieve Active Tasks assigned to Staff", Description = "Fetches all active tasks assigned to a specific staff member.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskToStaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No active tasks found.")]
    public async Task<Response<IEnumerable<TaskToStaffResponseDto>>> GetActiveTasksByStaffIdAsync([FromRoute] long staffId)
    {
        var result = await _taskToStaffService.GetActiveTasksByStaffIdAsync(staffId);
        return result.Any()
            ? Response<IEnumerable<TaskToStaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<TaskToStaffResponseDto>>.ErrorResponse("No active tasks found.");
    }

    [HttpGet("due-tasks")]
    [SwaggerOperation(Summary = "Retrieve Due Tasks", Description = "Fetches all tasks that are due by a specific date.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Due tasks retrieved successfully.", typeof(Response<IEnumerable<TaskToStaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No due tasks found.")]
    public async Task<Response<IEnumerable<TaskToStaffResponseDto>>> GetDueTasksAsync([FromQuery] DateTime dueDate)
    {
        var result = await _taskToStaffService.GetDueTasksAsync(dueDate);
        return result.Any()
            ? Response<IEnumerable<TaskToStaffResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<TaskToStaffResponseDto>>.ErrorResponse("No due tasks found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Tasks assigned to Staff", Description = "Returns all task-to-staff records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskToStaffResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<TaskToStaffResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Task assigned to Staff by ID", Description = "Fetches a specific task-to-staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskToStaffResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }


    [HttpGet("{taskId:long}")]
    [SwaggerOperation(Summary = "Retrieve a Task assigned to Staff by taskId", Description = "Fetches a specific task-to-staff record by task ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public async Task<Response<TaskToStaffResponseDto>> GetByTaskId([FromRoute] long taskId)
    {
        var res = await _taskToStaffService.GetByTaskIdAsync(taskId);
        if (res == null) return Response<TaskToStaffResponseDto>.ErrorResponse("No data found");

        return Response<TaskToStaffResponseDto>.SuccessResponse(res);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Assign a Task to Staff", Description = "Adds a new task-to-staff record.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskToStaffResponseDto>> CreateAsync([FromBody] TaskToStaffDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update a Task assigned to Staff", Description = "Updates an existing task-to-staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskToStaffResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskToStaffDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Task assigned to Staff", Description = "Deletes a task-to-staff record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<TaskToStaffResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Tasks assigned to Staff", Description = "Deletes multiple task-to-staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<TaskToStaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Tasks assigned to Staff", Description = "Updates multiple task-to-staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<TaskToStaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk assign Tasks to Staff", Description = "Adds multiple task-to-staff records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<TaskToStaffDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Task assigned to Staff", Description = "Marks a task-to-staff record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskToStaffResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskToStaffResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
