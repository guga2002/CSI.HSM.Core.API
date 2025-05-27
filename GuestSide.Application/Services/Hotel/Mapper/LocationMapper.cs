using AutoMapper;
using Common.Data.Entities.Hotel.GeoLocation;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;

namespace Core.Application.Services.Hotel.Mapper;

public class LocationMapper : Profile
{

    public LocationMapper()
    {
        CreateMap<LocationRequestDto, Location>().ReverseMap();
        CreateMap<LocationResponse, Location>().ReverseMap();
    }
}
