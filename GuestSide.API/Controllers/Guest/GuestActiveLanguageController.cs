using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Guest;
using GuestSide.API.CustomExtendControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Guest;

[Route("api/[controller]")]
[ApiController]
public class GuestActiveLanguageController : CSIControllerBase<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>
{
    public GuestActiveLanguageController(IService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage> serviceProvider, IAdditionalFeatures<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
