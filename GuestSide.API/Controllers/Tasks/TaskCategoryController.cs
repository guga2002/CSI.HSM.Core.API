using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : CSIControllerBase<TaskCategoryDto, long, TaskCategory>
    {
        public TaskCategoryController(IService<TaskCategoryDto, long, TaskCategory> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all task categories.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all task categories.</returns>
        [HttpGet("GetAllTaskCategories")]
        [SwaggerOperation(Summary = "Retrieve all task categories", Description = "Returns a list of all task categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved task categories.", typeof(Response<IEnumerable<TaskCategoryDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No task categories found.")]
        public override Task<Response<IEnumerable<TaskCategoryDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a task category by its ID.
        /// </summary>
        /// <param name="id">The ID of the task category.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The task category matching the specified ID.</returns>
        [HttpGet("GetTaskCategoryById/{id}")]
        [SwaggerOperation(Summary = "Retrieve task category by ID", Description = "Returns a specific task category by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the task category.", typeof(Response<TaskCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task category not found.")]
        public override Task<Response<TaskCategoryDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new task category.
        /// </summary>
        /// <param name="entityDto">The task category to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created task category.</returns>
        [HttpPost("CreateTaskCategory")]
        [SwaggerOperation(Summary = "Create a new task category", Description = "Creates a new task category.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Task category created successfully.", typeof(Response<TaskCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<TaskCategoryDto>> CreateAsync([FromBody] TaskCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing task category.
        /// </summary>
        /// <param name="id">The ID of the task category to update.</param>
        /// <param name="entityDto">The updated task category data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated task category.</returns>
        [HttpPut("UpdateTaskCategory/{id}")]
        [SwaggerOperation(Summary = "Update an existing task category", Description = "Updates the task category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task category updated successfully.", typeof(Response<TaskCategoryDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<TaskCategoryDto>> UpdateAsync([FromRoute] long id, [FromBody] TaskCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a task category by its ID.
        /// </summary>
        /// <param name="id">The ID of the task category to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteTaskCategory/{id}")]
        [SwaggerOperation(Summary = "Delete a task category", Description = "Deletes the task category with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Task category deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Task category not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
