using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : CSIControllerBase<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
    {
        public TaskStatusController(
            IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> serviceProvider,
            IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
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
}
