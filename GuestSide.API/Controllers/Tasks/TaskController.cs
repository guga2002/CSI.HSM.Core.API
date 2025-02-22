using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Task.Task;
using Core.Core.Entities.Item;
using Core.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : CSIControllerBase<TaskDto, TaskResponseDto, long, Core.Entities.Task.Tasks>
    {
        private readonly ITaskService _taskService;

        public TaskController(
            ITaskService taskService,
            IService<TaskDto, TaskResponseDto, long, Core.Entities.Task.Tasks> serviceProvider,
            IAdditionalFeatures<TaskDto, TaskResponseDto, long, Core.Entities.Task.Tasks> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _taskService = taskService;
        }

        [HttpGet("GetTaskItemsByCartId/{cartId:long}")]
        [SwaggerOperation(Summary = "Retrieve Tasks by Cart ID", Description = "Fetches all tasks associated with a specific cart.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
        public async Task<Response<Dictionary<long, IEnumerable<TaskItem>>>> GetTaskItemsByCartIdAsync([FromRoute]long cartId)
        {
            var result = await _taskService.GetTaskItemsByCartIdAsync(cartId);
            return result.Any()
                ? Response < Dictionary<long, IEnumerable<TaskItem>>>.SuccessResponse(result)
                : Response < Dictionary<long, IEnumerable<TaskItem>>>.ErrorResponse("No tasks found.");
        }


        [HttpGet("by-cart/{cartId:long}")]
        [SwaggerOperation(Summary = "Retrieve Tasks by Cart ID", Description = "Fetches all tasks associated with a specific cart.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
        public async Task<Response<IEnumerable<TaskResponseDto>>> GetTasksByCartId([FromRoute] long cartId)
        {
            var result = await _taskService.GetTasksByCartId(cartId);
            return result.Any()
                ? Response<IEnumerable<TaskResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<TaskResponseDto>>.ErrorResponse("No tasks found.");
        }

        [HttpPatch("update-status/{taskId:long}")]
        [SwaggerOperation(Summary = "Update Task Status", Description = "Updates the status of a specific task.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task status updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found.")]
        public async Task<Response<bool>> UpdateTaskStatusAsync([FromRoute] long taskId, [FromBody] Core.Entities.Task.TaskStatus newStatus)
        {
            var result = await _taskService.UpdateTaskStatus(taskId, newStatus);
            return result
                ? Response<bool>.SuccessResponse(true, "Task status updated successfully.")
                : Response<bool>.ErrorResponse("Task not found.");
        }

        [HttpGet("by-status/{status}")]
        [SwaggerOperation(Summary = "Retrieve Tasks by Status", Description = "Fetches tasks filtered by status with an optional limit.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
        public async Task<Response<IEnumerable<TaskResponseDto>>> GetTasksByStatusAsync([FromRoute] Core.Entities.Task.TaskStatus status, [FromQuery] int limit = 50)
        {
            var result = await _taskService.GetTasksByStatus(status, limit);
            return result.Any()
                ? Response<IEnumerable<TaskResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<TaskResponseDto>>.ErrorResponse("No tasks found.");
        }

        [HttpGet("high-priority")]
        [SwaggerOperation(Summary = "Retrieve High-Priority Tasks", Description = "Fetches high-priority tasks with a specified limit.")]
        [SwaggerResponse(StatusCodes.Status200OK, "High-priority tasks retrieved successfully.", typeof(Response<IEnumerable<TaskResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No high-priority tasks found.")]
        public async Task<Response<IEnumerable<TaskResponseDto>>> GetHighPriorityTasksAsync([FromQuery] int limit = 10)
        {
            var result = await _taskService.GetHighPriorityTasks(limit);
            return result.Any()
                ? Response<IEnumerable<TaskResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<TaskResponseDto>>.ErrorResponse("No high-priority tasks found.");
        }

        // Standard CRUD Operations

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Tasks", Description = "Returns all task records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<TaskResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Task by ID", Description = "Fetches a specific task record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<TaskResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Task", Description = "Adds a new task record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<TaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskResponseDto>> CreateAsync([FromBody] TaskDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Task", Description = "Updates an existing task record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<TaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Task", Description = "Deletes a task record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<TaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<TaskResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        // Bulk Operations

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Tasks", Description = "Deletes multiple task records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<TaskDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Tasks", Description = "Updates multiple task records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<TaskDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Tasks", Description = "Adds multiple task records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<TaskDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        // Soft Delete Operation

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Task", Description = "Marks a task record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<TaskResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
