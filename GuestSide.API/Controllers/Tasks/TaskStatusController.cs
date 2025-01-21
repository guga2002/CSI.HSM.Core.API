using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskStatusController : CSIControllerBase<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
{
    public TaskStatusController(IService<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> serviceProvider, IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
