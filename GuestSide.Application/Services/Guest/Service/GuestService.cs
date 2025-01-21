using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.Interface.Guest;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Guest.Service;

public class GuestService : GenericService<GuestDto, GuestResponseDto, long, Guests>, IGuestService
{
    public GuestService(IMapper mapper,
        IGenericRepository<Guests> repository,
        ILogger<GenericService<GuestDto, GuestResponseDto, long, Guests>> logger,
        IAdditionalFeaturesRepository<Guests> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
