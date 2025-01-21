using Core.Application.DTOs.Request.Audio;
using Core.Application.DTOs.Response.Audio;
using Core.Application.Interface.GenericContracts;
using GuestSide.Core.Entities.Audio;

namespace Core.Application.Interface.Audio;

public interface IAudioResponseCategoryService:IService<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto,long,AudioResponseCategory>,
    IAdditionalFeatures<AudioResponseCategoryRequestDto, AudioResponseCategoryResponseDto, long, AudioResponseCategory>
{
}
