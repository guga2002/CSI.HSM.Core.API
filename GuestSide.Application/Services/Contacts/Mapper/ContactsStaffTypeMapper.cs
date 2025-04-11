using AutoMapper;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Domain.Core.Entities.Contacts;

namespace Core.Application.Services.Contacts.Mapper;

public class ContactsStaffTypeMapper : Profile
{
    public ContactsStaffTypeMapper()
    {
        CreateMap<ContactsStaffTypeDto, ContactsStaffType>().ReverseMap();
        CreateMap<ContactsStaffType, ContactsStaffTypeResponseDto>().ReverseMap();
    }
}
