using AutoMapper;
using Common.Data.Entities.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;

namespace Core.Application.Services.Room.Mapper;

public class QrCodeMapper : Profile
{
    public QrCodeMapper()
    {
        CreateMap<QRCodeDto, QRCode>().ReverseMap();
        CreateMap<QRCode, QRCodeResponseDto>().ReverseMap();
    }
}
