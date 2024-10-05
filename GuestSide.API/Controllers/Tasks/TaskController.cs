using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : CSIControllerBase<TaskDto, long, GuestSide.Core.Entities.Task.Tasks>
    {
        public TaskController(IService<TaskDto, long, GuestSide.Core.Entities.Task.Tasks> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
