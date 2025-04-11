using AutoMapper;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
using Core.Application.Services;
using Domain.Core.Entities.Contacts;
using Domain.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Contacts.Service;

public class ContactsStaffTypeService : GenericService<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>, IContactsStaffTypeService
{
    public ContactsStaffTypeService(IMapper mapper,
        IGenericRepository<ContactsStaffType> repository,
        ILogger<GenericService<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>>
        logger, IAdditionalFeaturesRepository<ContactsStaffType> additioalFeatures)
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
