using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Core.Entities.LogEntities;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.LogController;

[Route("api/[controller]")]
[ApiController]
public class LogController : CSIControllerBase<LogDto, LogResponseDto, long, Logs>
{
    public LogController(IService<LogDto, LogResponseDto, long, Logs> serviceProvider, IAdditionalFeatures<LogDto, LogResponseDto, long, Logs> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
