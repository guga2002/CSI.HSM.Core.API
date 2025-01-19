using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.Category;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Category.Services;

public class StaffCategoryService : GenericService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, IStaffCategoryService
{
    public StaffCategoryService(IMapper mapper,
        IGenericRepository<StaffCategory> repository, 
        ILogger<GenericService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>> logger,
        IAdditioalFeatures<StaffCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
