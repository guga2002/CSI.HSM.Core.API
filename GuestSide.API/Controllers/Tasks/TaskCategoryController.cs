using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : CSIControllerBase<TaskCategoryDto, long, TaskCategory>
    {
        public TaskCategoryController(IService<TaskCategoryDto, long, TaskCategory> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
