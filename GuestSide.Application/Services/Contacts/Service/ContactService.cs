using AutoMapper;
using Common.Data.Entities.Contacts;
using Common.Data.Interfaces.AbstractInterface;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Contacts.Service;

public class ContactService : GenericService<ContactDto, ContactResponseDto, long, Contact>, IContactService
{
    public ContactService(IMapper mapper, IGenericRepository<Contact> repository, 
        ILogger<GenericService<ContactDto, ContactResponseDto, long, Contact>> logger, 
        IAdditionalFeaturesRepository<Contact> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
