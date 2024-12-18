using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.LogInterfaces
{
    public interface ILogRepository:IGenericRepository<Logs>,IDisposable
    {
        //add another method
    }
}
