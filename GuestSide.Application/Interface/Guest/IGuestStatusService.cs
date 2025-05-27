using Common.Data.Entities.Guest;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Guest;

public interface IGuestStatusService : IService<StatusDto, GuestStatusResponseDto, long, Status>,
    IAdditionalFeatures<StatusDto, GuestStatusResponseDto, long, Status>
{
}
