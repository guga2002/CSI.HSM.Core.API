using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Infrastructure.Repositories.LogRepo;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Interfaces.LogInterfaces;
using GuestSide.Application.Interface.LogInterfaces;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.LogService.Mapper;

namespace Core.Application.Services.LogService.DI;

public static class LogDI
{
    public static void InjectLog(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Logs>, LogRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
        services.AddScoped<ILogService, Services.LogService>();
        services.AddScoped<IService<LogDto, LogResponseDto, long, Logs>, Services.LogService>();
        services.AddScoped<IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>, Services.LogService>();
        services.AddAutoMapper(typeof(LogMapper));
    }
}
