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
    public class TaskCategoryController : CSIControllerBase<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>
    {
        public TaskCategoryController(
            IService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory> serviceProvider,
            IAdditionalFeatures<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Task Categories", Description = "Returns all task category records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<TaskCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<TaskCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Task Category by ID", Description = "Fetches a specific task category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<TaskCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Task Category", Description = "Adds a new task category record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<TaskCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskCategoryResponseDto>> CreateAsync([FromBody] TaskCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Task Category", Description = "Updates an existing task category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<TaskCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Task Category", Description = "Deletes a task category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<TaskCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<TaskCategoryResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Task Categories", Description = "Deletes multiple task category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<TaskCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Task Categories", Description = "Updates multiple task category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<TaskCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Task Categories", Description = "Adds multiple task category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<TaskCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Task Category", Description = "Marks a task category record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<TaskCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<TaskCategoryResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
