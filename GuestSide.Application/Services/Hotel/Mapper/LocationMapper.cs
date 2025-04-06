using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;

namespace Core.Application.Services.Hotel.Mapper;

public class LocationMapper:Profile
{

    public LocationMapper()
    {
        CreateMap<LocationRequestDto, Location>().ReverseMap();
        CreateMap<LocationResponse, Location>().ReverseMap();
    }
}
