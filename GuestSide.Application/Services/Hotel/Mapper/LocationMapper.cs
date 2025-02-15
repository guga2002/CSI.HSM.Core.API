using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;

namespace Core.Application.Services.Hotel.Mapper;

public class LocationMapper:Profile
{

    public LocationMapper()
    {
        CreateMap<LocationrequestDto, Location>().ReverseMap();
        CreateMap<LocationResponse, Location>().ReverseMap();
    }
}
