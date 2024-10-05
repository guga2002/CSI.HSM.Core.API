using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : CSIControllerBase<TaskStatusDto, long, TasksStatus>
    {
        public TaskStatusController(IService<TaskStatusDto, long, TasksStatus> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
