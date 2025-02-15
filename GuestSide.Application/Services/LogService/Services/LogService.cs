using AutoMapper;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.Interface.LogInterfaces;
using Core.Core.Entities.LogEntities;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.LogService.Services;

public class LogService : GenericService<LogDto, LogResponseDto, long, Logs>, ILogService
{
    public LogService(IMapper mapper, 
        IGenericRepository<Logs> repository, 
        ILogger<GenericService<LogDto, LogResponseDto, long, Logs>> logger, 
        IAdditionalFeaturesRepository<Logs> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
