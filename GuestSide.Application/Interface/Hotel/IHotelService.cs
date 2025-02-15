using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Hotel;

public interface IHotelService : IService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>,
    IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>
{
}
