using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Task
{
    public interface ITaskRepository:IGenericRepository<Tasks>
    {
        Task<IEnumerable<Tasks>> GetTasksbycartId(long CartId,CancellationToken cancellationToken = default);
    }
}
