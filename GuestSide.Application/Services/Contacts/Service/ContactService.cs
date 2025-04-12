using AutoMapper;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.Contacts;
using Domain.Core.Entities.Contacts;
using Domain.Core.Interfaces.AbstractInterface;
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
