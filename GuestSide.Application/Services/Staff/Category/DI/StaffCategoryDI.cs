﻿using Microsoft.Extensions.DependencyInjection;
using Core.Application.Services.Staff.Category.Services;
using Core.Application.Interface.GenericContracts;
using Core.Application.Services.Staff.Category.Mapper;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Application.Interface.Staff.Category;
using Core.Application.DTOs.Response.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Infrastructure.Repositories.Staff;

namespace Core.Application.Services.Staff.Category.DI;

public static class StaffCategoryDI
{
    public static void InjectStaffCategory(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<StaffCategory>, StaffCategoryRepository>();
        services.AddScoped<IStaffCategoryRepository, StaffCategoryRepository>();
        services.AddScoped<IStaffCategoryService, StaffCategoryService>();
        services.AddScoped<IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, StaffCategoryService>();
        services.AddScoped<IAdditionalFeatures<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>, StaffCategoryService>();
        services.AddAutoMapper(typeof(StaffCategoryMapper));
    }
}
