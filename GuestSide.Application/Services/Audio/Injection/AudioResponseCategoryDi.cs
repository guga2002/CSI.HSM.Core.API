using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.Audio;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Audio.Mapper;
using Core.Application.Services.Audio.Service;
using Core.Application.DTOs.Response.Audio;
using Core.Application.DTOs.Request.Audio;
using Common.Data.Entities.Audio;
using Common.Data.Interfaces.Audio;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Audio;
using Common.Data.Repositories.AbstractRepository;

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
