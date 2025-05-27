using AutoMapper;
using Common.Data.Entities.Contacts;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;

namespace Core.Application.Services.Contacts.Mapper;

public class ContactMapper : Profile
{
    public ContactMapper()
    {
        CreateMap<ContactDto, Contact>().ReverseMap();
        CreateMap<Contact, ContactResponseDto>().ReverseMap();
    }
}
