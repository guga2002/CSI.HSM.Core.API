

using AutoMapper;
using Common.Data.Entities.Language;
using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;

namespace Core.Application.Services.Language.Mapper;

public class LanguagePackMapper : Profile
{

    public LanguagePackMapper()
    {
        CreateMap<LanguagePackDto, LanguagePack>().ReverseMap();
        CreateMap<LanguagePackResponseDto, LanguagePack>().ReverseMap();
    }
}
