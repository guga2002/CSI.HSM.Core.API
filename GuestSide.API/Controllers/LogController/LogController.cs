using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Log;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.LogEntities;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.LogController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : CSIControllerBase<LogDto,long,Logs>
    {
        public LogController(IService<LogDto, long, Logs> service):base(service)
        {
                
        }
    }
}
