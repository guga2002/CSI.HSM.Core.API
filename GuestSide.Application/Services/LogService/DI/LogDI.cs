using Microsoft.Extensions.DependencyInjection;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Entities.LogEntities;
using Domain.Core.Interfaces.LogEntities;
using Core.Application.Services.LogService.Mapper;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.LogInterfaces;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.DTOs.Request.LogModel;
using Core.Infrastructure.Repositories.LogRepo;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace Core.Application.Services.LogService.DI;

public static class LogDI
{
    public static void InjectLog(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Logs>, LogsRepository>();
        services.AddScoped<ILogsRepository, LogsRepository>();
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<IService<LogDto, LogResponseDto, long, Logs>, LogService>();
        services.AddScoped<IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>, LogService>();
        services.AddScoped<IAdditionalFeaturesRepository<Logs>, AdditionalFeaturesRepository<Logs>>();
        services.AddAutoMapper(typeof(LogMapper));
    }
}
