using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Audio;

namespace Core.Application.Interface.Audio;

public interface IAudioresponseService:IService<AudioRequestDto,AudioResponseDto,long,AudioResponse>,
    IAdditionalFeatures<AudioRequestDto, AudioResponseDto, long, AudioResponse>
{
}
