using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Core.Entities.LogEntities;

namespace GuestSide.Application.Interface.LogInterfaces;

public interface ILogService:IService<LogDto,LogResponseDto,long,Logs>,
    IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>
{
}
