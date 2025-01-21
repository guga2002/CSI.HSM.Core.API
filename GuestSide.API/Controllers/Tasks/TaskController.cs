using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskController : CSIControllerBase<TaskDto, TaskResponseDto, long, GuestSide.Core.Entities.Task.Tasks>
{
    public TaskController(IService<TaskDto, TaskResponseDto, long, Core.Entities.Task.Tasks> serviceProvider, IAdditionalFeatures<TaskDto, TaskResponseDto, long, Core.Entities.Task.Tasks> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
