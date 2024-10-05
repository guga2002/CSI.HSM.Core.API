using AutoMapper;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service
{
    public class QrCodeService:GenericService<QRCodeDto,long,QRCode>,IQrCodeService
    {
        public QrCodeService(IMapper mapper,
                             IGenericRepository<QRCode> repos,
                             ILogger<GenericService<QRCodeDto, long, QRCode>> logger)
            :base(mapper,repos, logger) { }
    }
}
