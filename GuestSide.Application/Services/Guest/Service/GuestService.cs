using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Guest;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Guest;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Guest.Service;

public class GuestService : GenericService<GuestDto, GuestResponseDto, long, Guests>, IGuestService
{
    private readonly IGuestRepository _guestRepository;
    private readonly IMapper _mapper;
    public GuestService(IMapper mapper,
        IGenericRepository<Guests> repository,
        ILogger<GenericService<GuestDto, GuestResponseDto, long, Guests>> logger,
        IAdditionalFeaturesRepository<Guests> additioalFeatures,
        IGuestRepository guestRepository)
        : base(mapper, repository, logger, additioalFeatures)
    {
        _guestRepository = guestRepository;
        _mapper = mapper; 
    }

    public async Task<RoomsResponseDto> GetRoomByGuestId(long GuestId)
    {
        var res=await _guestRepository.GetRoomByGuestId(GuestId);
        if(res is not null)
        {
            return _mapper.Map<RoomsResponseDto>(res);
        }
        throw new Exception("Data not found");
    }
}
