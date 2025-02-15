using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Category;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Category.Services;

public class StaffCategoryService : GenericService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, IStaffCategoryService
{
    public StaffCategoryService(IMapper mapper,
        IGenericRepository<StaffCategory> repository, 
        ILogger<GenericService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>> logger,
        IAdditionalFeaturesRepository<StaffCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
