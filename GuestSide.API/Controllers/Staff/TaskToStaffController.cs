using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToStaffController : CSIControllerBase<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>
    {
        private readonly ITaskToStaffService _taskToStaffService;

        public TaskToStaffController(
            IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> serviceProvider,
            IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff> additionalFeatures, ITaskToStaffService taskToStaffService)
            : base(serviceProvider, additionalFeatures)
        {
            _taskToStaffService = taskToStaffService;
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

        [HttpGet("{taskId: long}")]
        [SwaggerOperation(Summary = "Retrieve a Task assigned to Staff by taskId", Description = "Fetches a specific task-to-staff record by task ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<TaskToStaffResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public async Task<Response<TaskToStaffResponseDto>> GetByTaskId(long taskId)
        {
            var res =  await _taskToStaffService.GetByTaskId(taskId);
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
}
