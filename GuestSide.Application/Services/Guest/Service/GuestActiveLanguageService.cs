using AutoMapper;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.Guest;
using Core.Core.Entities.Guest;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Guest.Service;
public class GuestActiveLanguageService : GenericService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>, IGuestActiveLanguageService
{
    public GuestActiveLanguageService(IMapper mapper, IGenericRepository<GuestActiveLanguage> repository, ILogger<GenericService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>> logger, IAdditionalFeaturesRepository<GuestActiveLanguage> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
