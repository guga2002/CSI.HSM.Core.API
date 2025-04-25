using Domain.Core.Entities.Contacts;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Contacts;
using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interface.GenericContracts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.Services.Contacts.Mapper;
using Core.Application.Services.Contacts.Service;
using Core.Infrastructure.Repositories.Contacts;
using Core.Infrastructure.Repositories.AbstractRepository;

namespace Core.Application.Services.Contacts.Injection;

public static class ContactDI
{
    public static void InjectContact(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Contact>, ContactRepository>();
        services.AddScoped<IContactRespository, ContactRepository>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IService<ContactDto, ContactResponseDto, long, Contact>, ContactService>();
        services.AddScoped<IAdditionalFeatures<ContactDto, ContactResponseDto, long, Contact>, ContactService>();
        services.AddScoped<IAdditionalFeaturesRepository<Contact>, AdditionalFeaturesRepository<Contact>>();
        services.AddAutoMapper(typeof(ContactMapper));
    }
}
