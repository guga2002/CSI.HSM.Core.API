using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Task.TaskLogs;

public interface ITaskLogsService : IService<TaskLogDto, TaskLogResponse, long, Core.Entities.Task.TaskLogs>,
        IAdditionalFeatures<TaskLogDto, TaskLogResponse, long, Core.Entities.Task.TaskLogs>
{
}
