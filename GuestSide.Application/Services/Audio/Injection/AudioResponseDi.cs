using Core.Application.Interface.GenericContracts;
using Core.Infrastructure.Repositories.AbstractRepository;
using Microsoft.Extensions.DependencyInjection;
using Core.Infrastructure.Repositories.Audio;
using Core.Application.Interface.Audio;
using Core.Application.Services.Audio.Service;
using Core.Application.Services.Audio.Mapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Audio;
using Domain.Core.Entities.Audio;
namespace Core.Application.Services.Audio.Injection;

public static class AudioResponseDi
{
    public static void InjectAudioResponse(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IGenericRepository<AudioResponse>, AudioResponseRepository>();
        serviceProvider.AddScoped<IAdditionalFeaturesRepository<AudioResponse>, AdditionalFeaturesRepository<AudioResponse>>();
        serviceProvider.AddScoped<IAudioResponseRepository, AudioResponseRepository>();
        serviceProvider.AddScoped<IAudioResponseService, AudioResponseService>();
        serviceProvider.AddScoped<IService<AudioRequestDto, AudioResponseDto, long, AudioResponse>, AudioResponseService>();
        serviceProvider.AddScoped<IAdditionalFeatures<AudioRequestDto, AudioResponseDto, long, AudioResponse>, AudioResponseService>();
        serviceProvider.AddAutoMapper(typeof(AudioResponseMapper));
    }
}
