using Authorization.Domain;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Task;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskController : CSIControllerBase<TaskDto, TaskResponseDto, long, GuestSide.Core.Entities.Task.Tasks>
{
    private readonly ITaskService _taskService;
    public TaskController(IService<TaskDto, TaskResponseDto, 
        long, Core.Entities.Task.Tasks> serviceProvider, 
        IAdditionalFeatures<TaskDto, TaskResponseDto, long, 
            Core.Entities.Task.Tasks> additionalFeatures, ITaskService taskService)
        : base(serviceProvider, additionalFeatures)
    {
        _taskService = taskService;
    }

    /// <summary>
    /// Retrieves a task associated with the specified cart ID.
    /// </summary>
    /// <param name="cartId">The ID of the cart for which the task is to be retrieved.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A response containing the task details or an error message if the task is not found.</returns>
    [HttpGet(nameof(GetTaskbycartId))]
    [SwaggerOperation(
        Summary = "Retrieve task by cart ID",
        Description = "Fetches the task details associated with the given cart ID."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Task retrieved successfully", typeof(Response<TaskResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Task not found for the specified cart ID", typeof(Response<TaskResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid cart ID provided")]
    public async Task<Response<TaskResponseDto>> GetTaskbycartId(
        long cartId,
        CancellationToken cancellationToken = default)
    {
        if (cartId < 0)
            return Response<TaskResponseDto>.ErrorResponse("Invalid cart ID. It must be a positive value.");

        var result = await _taskService.GetTaskbycartId(cartId, cancellationToken);

        return result != null
            ? Response<TaskResponseDto>.SuccessResponse(result)
            : Response<TaskResponseDto>.ErrorResponse("Task not found for the specified cart ID.");
    }

}
