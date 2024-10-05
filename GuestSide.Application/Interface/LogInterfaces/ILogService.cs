using GuestSide.Application.DTOs.Log;
using GuestSide.Core.Entities.LogEntities;

namespace GuestSide.Application.Interface.LogInterfaces
{
    public interface ILogService:IService<LogDto,long,Logs>
    {
    }
}
