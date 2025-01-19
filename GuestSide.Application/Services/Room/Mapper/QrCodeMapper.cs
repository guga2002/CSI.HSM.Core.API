using AutoMapper;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class QrCodeMapper:Profile
{
    public QrCodeMapper()
    {
        CreateMap<QRCodeDto,QRCode>().ReverseMap();
        CreateMap<QRCode,QRCodeResponseDto>().ReverseMap();
    }
}
