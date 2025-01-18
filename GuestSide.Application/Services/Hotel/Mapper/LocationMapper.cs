using AutoMapper;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;

namespace Core.Application.Services.Hotel.Mapper;

public class LocationMapper:Profile
{

    public LocationMapper()
    {
        CreateMap<LocationrequestDto, GuestSide.Core.Entities.Hotel.GeoLocation.Location>().ReverseMap();
        CreateMap<LocationResponse, GuestSide.Core.Entities.Hotel.GeoLocation.Location>().ReverseMap();
    }
}
