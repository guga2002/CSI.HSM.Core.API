using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.Services.Contacts.Mapper;
using Core.Application.Services.Contacts.Service;
using Common.Data.Entities.Contacts;
using Common.Data.Interfaces.Contacts;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.AbstractRepository;
using Common.Data.Repositories.Contacts;

namespace Core.Application.Services.Contacts.Injection;

public static class ContactsStaffTypeDI
{
    public static void InjectContactsStaffType(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<ContactsStaffType>, ContactsStaffTypeRepository>();
        services.AddScoped<IContactsStaffTypeRepository, ContactsStaffTypeRepository>();
        services.AddScoped<IContactsStaffTypeService, ContactsStaffTypeService>();
        services.AddScoped<IService<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>, ContactsStaffTypeService>();
        services.AddScoped<IAdditionalFeatures<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>, ContactsStaffTypeService>();
        services.AddScoped<IAdditionalFeaturesRepository<ContactsStaffType>, AdditionalFeaturesRepository<ContactsStaffType>>();
        services.AddAutoMapper(typeof(ContactsStaffTypeMapper));
    }
}
