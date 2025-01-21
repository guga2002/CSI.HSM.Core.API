using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : CSIControllerBase<QRCodeDto, QRCodeResponseDto, long, QRCode>
    {
        public QrCodeController(IService<QRCodeDto, QRCodeResponseDto, long, QRCode> serviceProvider, IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode> additionalFeatures) : base(serviceProvider, additionalFeatures)
        {
        }
    }
}
