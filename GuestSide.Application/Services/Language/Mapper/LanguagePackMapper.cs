

using AutoMapper;
using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;

namespace Core.Application.Services.Language.Mapper;

public class LanguagePackMapper:Profile
{

    public LanguagePackMapper()
    {
            CreateMap<LanguagePackDto, GuestSide.Core.Entities.Language.LanguagePack>().ReverseMap();
        CreateMap<LanguagePackResponseDto, GuestSide.Core.Entities.Language.LanguagePack>().ReverseMap();
    }
}
