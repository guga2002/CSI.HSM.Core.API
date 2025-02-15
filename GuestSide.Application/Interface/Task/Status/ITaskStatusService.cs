using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Task;

namespace Core.Application.Interface.Task.Status;

public interface ITaskStatusService : IService<TaskStatusDto, TaskStatusResponseDto, long,TasksStatus>,
    IAdditionalFeatures<TaskStatusDto, TaskStatusResponseDto, long, TasksStatus>
{
}
