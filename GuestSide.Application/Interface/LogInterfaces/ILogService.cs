using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.LogEntities;

namespace Core.Application.Interface.LogInterfaces;

public interface ILogService : IService<LogDto, LogResponseDto, long, Logs>,
    IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>
{
}
