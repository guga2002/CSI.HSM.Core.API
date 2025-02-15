using AutoMapper;
using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.Language;
using Core.Core.Entities.Language;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Language.Service;

public class LanguageService : GenericService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>, ILanguageService
{
    public LanguageService(IMapper mapper, IGenericRepository<LanguagePack> repository, ILogger<GenericService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>> logger, IAdditionalFeaturesRepository<LanguagePack> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
