using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Task.Task;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : CSIControllerBase<TaskDto, long, GuestSide.Core.Entities.Task.Tasks>
    {
        private readonly ITaskService _taskService;

        public TaskController(IService<TaskDto, long, GuestSide.Core.Entities.Task.Tasks> serviceProvider, ITaskService taskService)
            : base(serviceProvider)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Retrieves all guest notifications.
        /// </summary>
        /// <param name="CardId">Token to cancel the request.</param>
        /// <returns>A list of all guest notifications.</returns>
        [HttpGet("GetTaskByCartId")]
        [SwaggerOperation(Summary = "Retrieve all guest notifications", Description = "Returns a list of all guest notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved notifications.", typeof(Response<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
        public  async Task<Response<TaskDto>> GetTaskByCartId([FromQuery] long CardId)
        {
            var result = await _taskService.GetTaskbycartId(CardId);

            if (result != null)
            {
                return Response<TaskDto>.SuccessResponse(result);
            }
            return Response<TaskDto>.ErrorResponse("Record not found.", 404);
        }

        /// <summary>
        /// Retrieves all guest notifications.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all guest notifications.</returns>
        [HttpGet("GetAllTasks")]
        [SwaggerOperation(Summary = "Retrieve all guest notifications", Description = "Returns a list of all guest notifications.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved notifications.", typeof(Response<IEnumerable<TaskDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found.")]
        public override async Task<Response<IEnumerable<TaskDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = await base.GetAllAsync(cancellationToken);
            // Add any additional processing or logging here if needed.
            return response;
        }

        /// <summary>
        /// Retrieves a specific guest notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest notification.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The guest notification matching the specified ID.</returns>
        [HttpGet("GetTaskById/{id}")]
        [SwaggerOperation(Summary = "Retrieve guest notification by ID", Description = "Returns a specific guest notification by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the guest notification.", typeof(Response<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest notification not found.")]
        public override async Task<Response<TaskDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var response = await base.GetByIdAsync(id, cancellationToken);
            // Custom logging or processing can be added here
            return response;
        }

        /// <summary>
        /// Creates a new guest notification.
        /// </summary>
        /// <param name="entityDto">The guest notification to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created guest notification.</returns>
        [HttpPost("CreateTask")]
        [SwaggerOperation(Summary = "Create a new guest notification", Description = "Creates a new guest notification.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Guest notification created successfully.", typeof(Response<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskDto>> CreateAsync([FromBody] TaskDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Description))
            {
                return Response<TaskDto>.ErrorResponse("Invalid input data.", 400);
            }
            var response = await base.CreateAsync(entityDto, cancellationToken);
            return response;
        }

        /// <summary>
        /// Updates an existing guest notification.
        /// </summary>
        /// <param name="id">The ID of the guest notification to update.</param>
        /// <param name="entityDto">The updated guest notification data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated guest notification.</returns>
        [HttpPut("UpdateTask/{id}")]
        [SwaggerOperation(Summary = "Update an existing guest notification", Description = "Updates the guest notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest notification updated successfully.", typeof(Response<TaskDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<TaskDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Title))
            {
                return Response<TaskDto>.ErrorResponse("Invalid input data.", 400);
            }
            var response = await base.UpdateAsync(id, entityDto, cancellationToken);
            return response;
        }

        /// <summary>
        /// Deletes a guest notification by its ID.
        /// </summary>
        /// <param name="id">The ID of the guest notification to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteTask/{id}")]
        [SwaggerOperation(Summary = "Delete a guest notification", Description = "Deletes the guest notification with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Guest notification deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Guest notification not found or failed to delete.")]
        public override async Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var response = await base.DeleteAsync(id, cancellationToken);
            return response;
        }

        // Additional methods can be added here
    }
}
