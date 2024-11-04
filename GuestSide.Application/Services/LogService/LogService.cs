using AutoMapper;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Application.Interface.LogInterfaces;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.LogService
{
    public class LogService:GenericService<LogDto,LogResponseDto, long,Logs>,ILogService
    {
        public LogService(IMapper mapper, 
            IGenericRepository<Logs> repos, 
            ILogger<GenericService<LogDto,LogResponseDto, long,Logs>>logger)
            :base(mapper,repos,logger)
        {
        }
    }
}
