﻿using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.DependencyInjection;
using GuestSide.Core.Entities.Staff;
using GuestSide.Infrastructure.Repositories.Staff;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.AbstractInterface;
using Core.Application.Services.Staff.Cart.Services;

namespace Core.Application.Services.Staff.Cart.DI
{
    public static class TaskToStaffDi
    {
        public static void InjectCartToStaff(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<TaskToStaff>, TaskToStaffRepository>();
            services.AddScoped<IAdditionalFeaturesRepository<TaskToStaff>, AdditionalFeaturesRepository<TaskToStaff>>();
            services.AddScoped<ITaskToStaffRepository, TaskToStaffRepository>();
            services.AddScoped<ITaskToStaffService, TaskToStaffService>();
            services.AddScoped<IService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, TaskToStaffService>();
            services.AddScoped<IAdditionalFeatures<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, TaskToStaffService>();
        }
    }
}
