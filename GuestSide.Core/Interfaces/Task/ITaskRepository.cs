using Core.Core.Entities.Task;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Task
{
    public interface ITaskRepository : IGenericRepository<Tasks>
    {
        Task<IEnumerable<Tasks>> GetTasksbycartId(long CartId, CancellationToken cancellationToken = default);
    }
}
