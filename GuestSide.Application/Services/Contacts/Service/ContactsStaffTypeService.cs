using AutoMapper;
using Common.Data.Entities.Contacts;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
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
