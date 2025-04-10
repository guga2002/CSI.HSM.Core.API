using Domain.Core.Entities.Task;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Task
{
    public interface ITaskStatusRepository : IGenericRepository<TasksStatus>
    {
        Task<TasksStatus?> GetStatusByName(string statusName);
        Task<bool> UpdateTaskStatusName(long statusId, string newName);
        Task<IEnumerable<TasksStatus>> GetAllActiveStatuses();
    }
}