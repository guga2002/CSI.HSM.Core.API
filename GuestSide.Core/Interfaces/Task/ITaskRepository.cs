using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Task
{
    public interface ITaskRepository:IGenericRepository<Tasks>
    {
        Task<Tasks> GetTaskbycartId(long CartId,CancellationToken cancellationToken = default);
    }
}
