using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Core.Entities.Language;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Language;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : CSIControllerBase<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>
{
    public LanguageController(IService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack> serviceProvider, IAdditionalFeatures<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
