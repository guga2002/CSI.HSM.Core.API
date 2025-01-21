using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Guest;

namespace Core.Application.Interface.Guest;

public interface IGuestActiveLanguageService: IService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>,
    IAdditionalFeatures<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>
{
}
