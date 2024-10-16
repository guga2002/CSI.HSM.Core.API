using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Task.Task;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : CSIControllerBase<TaskDto, long, GuestSide.Core.Entities.Task.Tasks>
    {
        private readonly ITaskService tasks;
        public TaskController(IService<TaskDto, long, GuestSide.Core.Entities.Task.Tasks> serviceProvider,ITaskService ser) : base(serviceProvider)
        {
            this.tasks = ser;
        }

        [HttpGet]
        [Route(nameof(getTaskbycartId))]
        public async Task<Response<TaskDto>> getTaskbycartId([FromQuery] long CardId)
        {
            var res = await tasks.GetTaskbycartId(CardId);

            if (res != null)
            {
                return Response<TaskDto>.SuccessResponse(res);
            }
            return Response<TaskDto>.ErrorResponse("Record not found.", 404);
        }
    }
}
