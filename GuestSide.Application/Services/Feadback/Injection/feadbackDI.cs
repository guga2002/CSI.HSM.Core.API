﻿using Core.Application.DTOs.Request.FeedBacks;
using Core.Application.DTOs.Response.FeedBacks;
using Core.Application.Interface.FeedBack;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Feadback.Mapper;
using Core.Core.Entities.FeedBacks;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.FeedBack;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.FeedBack;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Services.Feadback.Injection;

public static class feadbackDI
{
    public static void InjectFeadbacks(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Feedback>, FeedbackRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IFeadbackService, FeedbackService>();
        services.AddScoped<IService<FeedbackDto, FeedbackResponseDto, long, Feedback>, FeedbackService>();
        services.AddScoped<IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback>, FeedbackService>();
        services.AddScoped<IAdditionalFeaturesRepository<Feedback>, AdditionalFeaturesRepository<Feedback>>();
        services.AddAutoMapper(typeof(FeadbackMapper));
        /// services.AddScoped<ILogger<GenericService<FeedbackDto, long, Feedback>>>();
    }
}
