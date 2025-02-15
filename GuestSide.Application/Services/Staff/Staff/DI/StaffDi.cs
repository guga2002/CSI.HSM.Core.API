﻿using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Staff.Staff.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Staff.Staff.Mapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.Interface.Staff.staf;
using Core.Infrastructure.Repositories.Staff;

namespace Core.Application.Services.Staff.Staff.DI;

public static class StaffDi
{
    public static void InjectStaffs(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Staffs>, StaffRepository>();
        services.AddScoped<IAdditionalFeaturesRepository<Staffs>, AdditionalFeaturesRepository<Staffs>>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IStaffService,StaffService> ();
        services.AddScoped<IService<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddScoped<IAdditionalFeatures<StaffDto, StaffResponseDto, long, Staffs>, StaffService>();
        services.AddAutoMapper(typeof(StaffMapper));

    }
}
