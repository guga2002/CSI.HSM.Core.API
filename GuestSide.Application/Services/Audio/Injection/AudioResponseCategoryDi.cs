using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.Audio;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Audio.Mapper;
using Core.Application.Services.Audio.Service;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Audio;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.Audio;
using System;
using Microsoft.Extensions.DependencyInjection;
using Core.Core.Entities.Audio;

namespace Core.Application.Services.Audio.Injection;
public static class AudioResponseCategoryDi
{

    public static void InjectAudioResponseCategory(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IGenericRepository<AudioResponseCategory>, AudioResponseCategoryRepository>();
        serviceProvider.AddScoped<IAdditionalFeaturesRepository<AudioResponseCategory>, AdditionalFeaturesRepository<AudioResponseCategory>>();
        serviceProvider.AddScoped<IAudioResponseCategoryRepository, AudioResponseCategoryRepository>();
        serviceProvider.AddScoped<IAudioResponseCategoryService, AudioResponseCategoryService>();
        serviceProvider.AddScoped<IService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>, AudioResponseCategoryService>();
        serviceProvider.AddScoped<IAdditionalFeatures<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>, AudioResponseCategoryService>();
        serviceProvider.AddAutoMapper(typeof(AudioResponseCategoryMapper));
    }
}
