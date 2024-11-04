using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room
{
    public interface IQrCodeService:IService<QRCodeDto,QRCodeResponseDto,long,QRCode>
    {
    }
}
