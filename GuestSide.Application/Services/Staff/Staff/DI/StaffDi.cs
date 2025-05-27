using Microsoft.Extensions.DependencyInjection;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.staf;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Request.Staff;
using Core.Application.Services.Staff.Staff.Services;
using Core.Application.Services.Staff.Staff.Mapper;
using Common.Data.Entities.Staff;
using Common.Data.Interfaces.Staff;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.Staff;
using Common.Data.Repositories.AbstractRepository;

namespace Core.Application.Services.Staff.Staff.DI;

public static class StaffDi
{
    public static void InjectStaffs(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Staffs>, StaffRepository>();
        services.AddScoped<IAdditionalFeaturesRepository<Staffs>, AdditionalFeaturesRepository<Staffs>>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IService<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddScoped<IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddAutoMapper(typeof(StaffMapper));

    }
}
