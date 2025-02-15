using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Room;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Room.Service;

public class QrCodeService : GenericService<QRCodeDto, QRCodeResponseDto, long, QRCode>, IQrCodeService
{
    public QrCodeService(IMapper mapper,
        IGenericRepository<QRCode> repository,
        ILogger<GenericService<QRCodeDto, QRCodeResponseDto, long, QRCode>> logger,
        IAdditionalFeaturesRepository<QRCode> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
