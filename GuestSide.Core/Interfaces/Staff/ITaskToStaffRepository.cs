using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Sheared;

namespace Core.Core.Interfaces.Staff
{
    public interface ITaskToStaffRepository : IGenericRepository<TaskToStaff>
    {
        Task<TaskToStaff> GetByTaskId(long taskId);
        Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCard(long cardId);
    }
}
