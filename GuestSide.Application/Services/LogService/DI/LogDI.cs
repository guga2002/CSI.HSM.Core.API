﻿using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.LogService.Mapper;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.Interface.LogInterfaces;
using Core.Infrastructure.Repositories.LogRepo;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.LogInterfaces;
using Domain.Core.Entities.LogEntities;

namespace Core.Application.Services.LogService.DI;

public static class LogDI
{
    public static void InjectLog(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Logs>, LogsRepository>();
        services.AddScoped<ILogsRepository, LogsRepository>();
        services.AddScoped<ILogService, Services.LogService>();
        services.AddScoped<IService<LogDto, LogResponseDto, long, Logs>, Services.LogService>();
        services.AddScoped<IAdditionalFeatures<LogDto, LogResponseDto, long, Logs>, Services.LogService>();
        services.AddScoped<IAdditionalFeaturesRepository<Logs>, AdditionalFeaturesRepository<Logs>>();
        services.AddAutoMapper(typeof(LogMapper));
    }
}
