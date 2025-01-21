using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service;

public class QrCodeService : GenericService<QRCodeDto, QRCodeResponseDto, long, QRCode>, IQrCodeService
{
    public QrCodeService(IMapper mapper, 
        IGenericRepository<QRCode> repository,
        ILogger<GenericService<QRCodeDto, QRCodeResponseDto, long, QRCode>> logger, 
        IAdditionalFeaturesRepository<QRCode> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
