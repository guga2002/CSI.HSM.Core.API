using AutoMapper;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface.Staff.Category;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Staff.Category
{
    public class StaffCategoryService : GenericService<StaffCategoryDto, long, GuestSide.Core.Entities.Staff.StaffCategory>, IStaffCategoryService
    {
        public StaffCategoryService(IMapper mapper, IGenericRepository<StaffCategory> repository, ILogger<GenericService<StaffCategoryDto, long, StaffCategory>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
