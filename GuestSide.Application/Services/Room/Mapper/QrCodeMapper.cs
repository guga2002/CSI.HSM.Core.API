﻿using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Domain.Core.Entities.Room;

namespace Core.Application.Services.Room.Mapper;

public class QrCodeMapper:Profile
{
    public QrCodeMapper()
    {
        CreateMap<QRCodeDto,QRCode>().ReverseMap();
        CreateMap<QRCode,QRCodeResponseDto>().ReverseMap();
    }
}
