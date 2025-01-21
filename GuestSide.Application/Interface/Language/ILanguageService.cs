using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using GuestSide.Core.Entities.Language;

namespace Core.Application.Interface.Language
{
    public interface ILanguageService:IService<LanguagePackDto,LanguagePackResponseDto,long,LanguagePack>,
        IAdditionalFeatures<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>
    {
    }
}
