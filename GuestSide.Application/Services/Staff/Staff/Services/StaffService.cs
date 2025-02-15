using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.staf;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Staff.Services;

public class StaffService : GenericService<StaffDto, StaffResponseDto, long, Staffs>, IStaffService
{
    public StaffService(IMapper mapper, 
        IGenericRepository<Staffs> repository, 
        ILogger<GenericService<StaffDto, StaffResponseDto, long, Staffs>> logger,
        IAdditionalFeaturesRepository<Staffs> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
