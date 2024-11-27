using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Hotel;
using GuestSide.Core.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.Interface.Hotel
{
    public interface IHotelService: IService<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>
    {
    }
}
