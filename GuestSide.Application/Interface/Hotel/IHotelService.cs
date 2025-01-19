using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;

namespace GuestSide.Application.Interface.Hotel;

public interface IHotelService: IService<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>,
    IAdditionalFeatures<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>
{
}
