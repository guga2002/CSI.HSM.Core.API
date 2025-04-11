using AutoMapper;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Domain.Core.Entities.Guest;

namespace Core.Application.Services.Guest.Mapper;

public class GuestStatusMapper : Profile
{
    public GuestStatusMapper()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
        CreateMap<Status, GuestStatusResponseDto>().ReverseMap();
    }
}
