using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : CSIControllerBase<QRCodeDto,long,QRCode>
    {
        public QrCodeController(IService<QRCodeDto, long, QRCode> service):base(service) { }
        
        
    }
}
