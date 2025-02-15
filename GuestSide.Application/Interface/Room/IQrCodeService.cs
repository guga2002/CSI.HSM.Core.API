using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Room;

namespace Core.Application.Interface.Room;

public interface IQrCodeService : IService<QRCodeDto, QRCodeResponseDto, long, QRCode>,
    IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode>
{
}
