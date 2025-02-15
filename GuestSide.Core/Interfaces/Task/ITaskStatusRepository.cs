using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Task
{
    public interface ITaskStatusRepository : IGenericRepository<TasksStatus>
    {
        Task<TasksStatus?> GetStatusByName(string statusName);
        Task<bool> UpdateTaskStatusName(long statusId, string newName);
        Task<IEnumerable<TasksStatus>> GetAllActiveStatuses();
    }
}