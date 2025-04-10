using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Room.Mapper;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Application.Services.Room.Service;
using Core.Application.Interface.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Infrastructure.Repositories.Room;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Room;
using Domain.Core.Entities.Room;

namespace Core.Application.Services.Room.DI;

public static class QrCodeDI
{
    public static void InjectQrCode(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<QRCode>, QRCodeRepository>();
        services.AddScoped<IQRCodeRepository, QRCodeRepository>();
        services.AddScoped<IQrCodeService, QrCodeService>();
        services.AddScoped<IService<QRCodeDto, QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode>, QrCodeService>();
        services.AddScoped<IAdditionalFeaturesRepository<QRCode>, AdditionalFeaturesRepository<QRCode>>();
        services.AddAutoMapper(typeof(QrCodeMapper));
    }
}
