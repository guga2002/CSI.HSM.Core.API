using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Infrastructure.Repositories.Staff;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Application.Interface.Staff.staf;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using Core.Application.Services.Staff.Staff.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Staff.Staff.Mapper;

namespace Core.Application.Services.Staff.Staff.DI;

public static class StaffDi
{
    public static void InjectStaffs(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Staffs>, StaffRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IStaffService,StaffService> ();
        services.AddScoped<IService<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddScoped<IService<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddAutoMapper(typeof(StaffMapper));

    }
}
