using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.Interface.Hotel;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Hotel;

public class HotelService : GenericService<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>, IHotelService
{
    public HotelService(IMapper mapper, 
        IGenericRepository<Core.Entities.Hotel.Hotel> repository, 
        ILogger<GenericService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>> logger,
        IAdditionalFeaturesRepository<Core.Entities.Hotel.Hotel> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
