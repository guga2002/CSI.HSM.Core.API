using AutoMapper;
using Core.Application.DTOs.Request.Hotel;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.Interface.Hotel;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Hotel;

public class HotelService : GenericService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>, IHotelService
{
    public HotelService(IMapper mapper,
        IGenericRepository<Core.Entities.Hotel.Hotel> repository,
        ILogger<GenericService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel>> logger,
        IAdditionalFeaturesRepository<Core.Entities.Hotel.Hotel> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
