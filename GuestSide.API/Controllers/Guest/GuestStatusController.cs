using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Guest;

[Route("api/[controller]")]
[ApiController]
public class GuestStatusController : CSIControllerBase<StatusDto, GuestStatusResponseDto, long, Status>
{
    public GuestStatusController(IService<StatusDto, GuestStatusResponseDto, long, Status> serviceProvider, IAdditionalFeatures<StatusDto, GuestStatusResponseDto, long, Status> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
