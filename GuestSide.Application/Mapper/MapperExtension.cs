using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Core.Entities.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;

namespace GuestSide.Application.Mapper
{
    public partial class AutoMapper
    {
        public void ConfigureExternalMappings()
        {
            CreateMap<Hotel, HotelRequestDto>().ReverseMap();
            CreateMap<Hotel, HotelResponse>().ReverseMap();
            CreateMap<Location, LocationrequestDto>().ReverseMap();
            CreateMap<Location, LocationResponse>().ReverseMap(); 
        }
    }
}
