using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Domain.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class TaskItemController : CSIControllerBase<TaskItemDto, TaskItemResponseDto, long, TaskItem>
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(
        IService<TaskItemDto, TaskItemResponseDto, long, TaskItem> serviceProvider,
        IAdditionalFeatures<TaskItemDto, TaskItemResponseDto, long, TaskItem> additionalFeatures,
        ITaskItemService taskItemService)
        : base(serviceProvider, additionalFeatures)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet("TaskItemByTask/{taskId:long}")]
    [SwaggerOperation(Summary = "Retrieve Task Items by Task ID", Description = "Fetches all task items associated with a specific task.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<TaskItemResponseDto>>> GetTaskItemsByTaskIdAsync([FromRoute] long taskId, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.GetTaskItemsByTaskIdAsync(taskId, cancellationToken);
        return result.Any() ? Response<IEnumerable<TaskItemResponseDto>>.SuccessResponse(result) : Response<IEnumerable<TaskItemResponseDto>>.ErrorResponse("No task items found.");
    }

    [HttpGet("ByItem/{itemId:long}")]
    [SwaggerOperation(Summary = "Retrieve Task Items by Item ID", Description = "Fetches all task items associated with a specific item.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<TaskItemResponseDto>>> GetTaskItemsByItemIdAsync([FromRoute] long itemId, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.GetTaskItemsByItemIdAsync(itemId, cancellationToken);
        return result.Any() ? Response<IEnumerable<TaskItemResponseDto>>.SuccessResponse(result) : Response<IEnumerable<TaskItemResponseDto>>.ErrorResponse("No task items found.");
    }

    [HttpGet("Pending")]
    [SwaggerOperation(Summary = "Retrieve all Pending Task Items", Description = "Fetches all task items that are still pending.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskItemResponseDto>>))]
    public async Task<Response<IEnumerable<TaskItemResponseDto>>> GetPendingTaskItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.GetPendingTaskItemsAsync(cancellationToken);
        return Response<IEnumerable<TaskItemResponseDto>>.SuccessResponse(result);
    }

    [HttpGet("Completed")]
    [SwaggerOperation(Summary = "Retrieve all Completed Task Items", Description = "Fetches all task items that have been marked as completed.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskItemResponseDto>>))]
    public async Task<Response<IEnumerable<TaskItemResponseDto>>> GetCompletedTaskItemsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.GetCompletedTaskItemsAsync(cancellationToken);
        return Response<IEnumerable<TaskItemResponseDto>>.SuccessResponse(result);
    }

    [HttpPatch("UpdateQuantity/{taskItemId:long}/{newQuantity:int}")]
    [SwaggerOperation(Summary = "Update Task Item Quantity", Description = "Updates the quantity of a task item.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Quantity updated successfully.", typeof(Response<bool>))]
    public async Task<Response<bool>> UpdateItemQuantityAsync([FromRoute] long taskItemId, [FromRoute] int newQuantity, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.UpdateItemQuantityAsync(taskItemId, newQuantity, cancellationToken);
        return result ? Response<bool>.SuccessResponse(true, "Quantity updated successfully.") : Response<bool>.ErrorResponse("Failed to update quantity.");
    }

    [HttpPatch("MarkTaskAsCompleted/{taskItemId:long}")]
    [SwaggerOperation(Summary = "Mark Task Item as Completed", Description = "Marks a task item as completed.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Task item marked as completed.", typeof(Response<bool>))]
    public async Task<Response<bool>> MarkTaskItemCompletedAsync([FromRoute] long taskItemId, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.MarkTaskItemCompletedAsync(taskItemId, cancellationToken);
        return result ? Response<bool>.SuccessResponse(true, "Task item marked as completed.") : Response<bool>.ErrorResponse("Failed to mark task item as completed.");
    }

    [HttpPatch("AddNotes/{taskItemId:long}")]
    [SwaggerOperation(Summary = "Add Notes to Task Item", Description = "Adds additional notes to a task item.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Notes added successfully.", typeof(Response<bool>))]
    public async Task<Response<bool>> AddNotesToTaskItemAsync([FromRoute] long taskItemId, [FromBody] string notes, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.AddNotesToTaskItemAsync(taskItemId, notes, cancellationToken);
        return result ? Response<bool>.SuccessResponse(true, "Notes added successfully.") : Response<bool>.ErrorResponse("Failed to add notes.");
    }

    [HttpGet("CountTotal/{taskId:long}")]
    [SwaggerOperation(Summary = "Count Total Items in a Task", Description = "Returns the total count of items associated with a task.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    public async Task<Response<int>> CountTotalItemsInTaskAsync([FromRoute] long taskId, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.CountTotalItemsInTaskAsync(taskId, cancellationToken);
        return Response<int>.SuccessResponse(result);
    }

    [HttpGet("CountCompleted/{taskId:long}")]
    [SwaggerOperation(Summary = "Count Completed Items in a Task", Description = "Returns the count of completed items associated with a task.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Count retrieved successfully.", typeof(Response<int>))]
    public async Task<Response<int>> CountCompletedItemsInTaskAsync([FromRoute] long taskId, CancellationToken cancellationToken = default)
    {
        var result = await _taskItemService.CountCompletedItemsInTaskAsync(taskId, cancellationToken);
        return Response<int>.SuccessResponse(result);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all TaskItem records", Description = "Returns all TaskItem records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<TaskItemResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a TaskItem by ID", Description = "Fetches a specific TaskItem record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskItemResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new TaskItem record", Description = "Adds a new TaskItem record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<TaskItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskItemResponseDto>> CreateAsync([FromBody] TaskItemDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing TaskItem record", Description = "Updates an existing TaskItem record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<TaskItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<TaskItemResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskItemDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a TaskItem record", Description = "Deletes a TaskItem record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<TaskItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<TaskItemResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete TaskItem records", Description = "Deletes multiple TaskItem records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<TaskItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update TaskItem records", Description = "Updates multiple TaskItem records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<TaskItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add TaskItem records", Description = "Adds multiple TaskItem records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<TaskItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a TaskItem record", Description = "Marks a TaskItem record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<TaskItemResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
