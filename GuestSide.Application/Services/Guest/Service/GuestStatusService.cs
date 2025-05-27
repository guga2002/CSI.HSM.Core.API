using AutoMapper;
using Common.Data.Entities.Guest;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.Guest;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Guest.Service;

public class GuestStatusService : GenericService<StatusDto, GuestStatusResponseDto, long, Status>, IGuestStatusService
{
    public GuestStatusService(IMapper mapper, IGenericRepository<Status> repository, ILogger<GenericService<StatusDto, GuestStatusResponseDto, long, Status>> logger, IAdditionalFeaturesRepository<Status> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
