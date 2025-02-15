using Core.Application.DTOs.Request.Task;
using Core.Application.DTOs.Response.Task;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Task;

namespace Core.Application.Interface.Task.Task;

public interface ITaskService : IService<TaskDto, TaskResponseDto, long, Tasks>,
    IAdditionalFeatures<TaskDto, TaskResponseDto, long, Tasks>
{
    Task<IEnumerable<TaskResponseDto>> GetTasksbycartId(long CartId, CancellationToken cancellationToken = default);
}
