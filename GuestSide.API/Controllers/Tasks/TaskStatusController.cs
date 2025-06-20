﻿using Common.Data.Entities.Task;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.Status;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskStatusController : CSIControllerBase<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
{
    private readonly ITaskStatusService _taskStatusService;

    public TaskStatusController(
        ITaskStatusService taskStatusService,
        IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> serviceProvider,
        IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _taskStatusService = taskStatusService;
    }

    [HttpGet("all")]
    [SwaggerOperation(Summary = "Retrieve all Task Statuses", Description = "Returns all available task status records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskStatusResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<TaskStatusResponseDto>>> GetAllTaskStatusesAsync()
    {
        var result = await _taskStatusService.GetAllTaskStatusesAsync();
        return result.Any()
            ? Response<IEnumerable<TaskStatusResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<TaskStatusResponseDto>>.ErrorResponse("No task statuses found.");
    }

    [HttpGet("by-name/{statusName}")]
    [SwaggerOperation(Summary = "Retrieve a Task Status by Name", Description = "Fetches a specific task status record by its name.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public async Task<Response<TaskStatusResponseDto>> GetTaskStatusByNameAsync([FromRoute] string statusName)
    {
        var result = await _taskStatusService.GetTaskStatusByNameAsync(statusName);
        return result != null
            ? Response<TaskStatusResponseDto>.SuccessResponse(result)
            : Response<TaskStatusResponseDto>.ErrorResponse("Task status not found.");
    }

    [HttpPatch("update-name/{statusId:long}")]
    [SwaggerOperation(Summary = "Update Task Status Name", Description = "Updates the name of an existing task status.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task status updated successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public async Task<Response<bool>> UpdateTaskStatusNameAsync([FromRoute] long statusId, [FromBody] string newName)
    {
        var result = await _taskStatusService.UpdateTaskStatusNameAsync(statusId, newName);
        return result
            ? Response<bool>.SuccessResponse(true, "Task status name updated successfully.")
            : Response<bool>.ErrorResponse("Failed to update task status name.");
    }

    [HttpGet("active")]
    [SwaggerOperation(Summary = "Retrieve Active Task Statuses", Description = "Fetches all active task status records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskStatusResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<TaskStatusResponseDto>>> GetAllActiveStatusesAsync()
    {
        var result = await _taskStatusService.GetAllActiveStatusesAsync();
        return result.Any()
            ? Response<IEnumerable<TaskStatusResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<TaskStatusResponseDto>>.ErrorResponse("No active task statuses found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Task Statuses", Description = "Returns all task status records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskStatusResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<TaskStatusResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Task Status by ID", Description = "Fetches a specific task status record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskStatusResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Task Status", Description = "Adds a new task status record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskStatusResponseDto>> CreateAsync([FromBody] TaskStatusDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Task Status", Description = "Updates an existing task status record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskStatusResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskStatusDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Task Status", Description = "Deletes a task status record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskStatusResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Task Statuses", Description = "Deletes multiple task status records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<TaskStatusDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Task Statuses", Description = "Updates multiple task status records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<TaskStatusDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Task Statuses", Description = "Adds multiple task status records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<TaskStatusDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Task Status", Description = "Marks a task status record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskStatusResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskStatusResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
