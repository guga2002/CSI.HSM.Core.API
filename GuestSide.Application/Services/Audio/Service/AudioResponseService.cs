using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.Audio;
using Core.Core.Entities.Audio;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Audio.Service;

public class AudioResponseService : GenericService<AudioRequestDto, AudioResponseDto, long, AudioResponse>, IAudioresponseService
{
    public AudioResponseService(IMapper mapper, IGenericRepository<AudioResponse> repository, ILogger<GenericService<AudioRequestDto, AudioResponseDto, long, AudioResponse>> logger, IAdditionalFeaturesRepository<AudioResponse> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
