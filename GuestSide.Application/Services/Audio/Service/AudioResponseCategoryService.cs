using AutoMapper;
using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.Audio;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Audio;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Audio.Service;

public class AudioResponseCategoryService : GenericService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>, IAudioResponseCategoryService
{
    public AudioResponseCategoryService(IMapper mapper, IGenericRepository<AudioResponseCategory> repository, ILogger<GenericService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>> logger, IAdditionalFeaturesRepository<AudioResponseCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
