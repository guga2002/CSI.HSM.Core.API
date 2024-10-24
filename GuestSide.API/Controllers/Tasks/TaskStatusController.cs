using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : CSIControllerBase<TaskStatusDto, long, TasksStatus>
    {
        public TaskStatusController(IService<TaskStatusDto, long, TasksStatus> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all task statuses.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all task statuses.</returns>
        [HttpGet("GetTaskStatuses")]
        [SwaggerOperation(Summary = "Retrieve all task statuses", Description = "Returns a list of all task statuses.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved task statuses.", typeof(Response<IEnumerable<TaskStatusDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No task statuses found.")]
        public override async Task<Response<IEnumerable<TaskStatusDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = await base.GetAllAsync(cancellationToken);
            // You can add custom logic here if needed
            return response;
        }

        /// <summary>
        /// Retrieves a specific task status by its ID.
        /// </summary>
        /// <param name="id">The ID of the task status.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The task status matching the specified ID.</returns>
        [HttpGet("GetTaskStatusById/{id}")]
        [SwaggerOperation(Summary = "Retrieve task status by ID", Description = "Returns a specific task status by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the task status.", typeof(Response<TaskStatusDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task status not found.")]
        public override async Task<Response<TaskStatusDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var response = await base.GetByIdAsync(id, cancellationToken);
            // Additional processing or logging can be added here
            return response;
        }

        /// <summary>
        /// Creates a new task status.
        /// </summary>
        /// <param name="entityDto">The task status to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created task status.</returns>
        [HttpPost("CreateTaskStatus")]
        [SwaggerOperation(Summary = "Create a new task status", Description = "Creates a new task status.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Task status created successfully.", typeof(Response<TaskStatusDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskStatusDto>> CreateAsync([FromBody] TaskStatusDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Description))
            {
                return Response<TaskStatusDto>.ErrorResponse("Invalid input data.", 400);
            }
            var response = await base.CreateAsync(entityDto, cancellationToken);
            return response;
        }

        /// <summary>
        /// Updates an existing task status.
        /// </summary>
        /// <param name="id">The ID of the task status to update.</param>
        /// <param name="entityDto">The updated task status data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated task status.</returns>
        [HttpPut("UpdateTaskStatus/{id}")]
        [SwaggerOperation(Summary = "Update an existing task status", Description = "Updates the task status with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task status updated successfully.", typeof(Response<TaskStatusDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskStatusDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskStatusDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Description))
            {
                return Response<TaskStatusDto>.ErrorResponse("Invalid input data.", 400);
            }
            var response = await base.UpdateAsync(id, entityDto, cancellationToken);
            return response;
        }

        /// <summary>
        /// Deletes a task status by its ID.
        /// </summary>
        /// <param name="id">The ID of the task status to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteTaskStatus/{id}")]
        [SwaggerOperation(Summary = "Delete a task status", Description = "Deletes the task status with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task status deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task status not found or failed to delete.")]
        public override async Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var response = await base.DeleteAsync(id, cancellationToken);
            return response;
        }

        // You can add more custom methods or functionalities as needed.
    }
}
