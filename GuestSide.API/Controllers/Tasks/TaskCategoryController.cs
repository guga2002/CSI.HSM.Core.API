using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TaskCategoryController : CSIControllerBase<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>
{
    public TaskCategoryController(IService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory> serviceProvider, IAdditionalFeatures<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
