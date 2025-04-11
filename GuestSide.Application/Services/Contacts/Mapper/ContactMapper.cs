using AutoMapper;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Domain.Core.Entities.Contacts;

namespace Core.Application.Services.Contacts.Mapper;

public class ContactMapper : Profile
{
    public ContactMapper()
    {
        CreateMap<ContactDto, Contact>().ReverseMap();
        CreateMap<Contact, ContactResponseDto>().ReverseMap();
    }
}
