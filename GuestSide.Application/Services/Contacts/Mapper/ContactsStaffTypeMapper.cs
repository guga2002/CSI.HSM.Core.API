using AutoMapper;
using Common.Data.Entities.Contacts;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;

namespace Core.Application.Services.Contacts.Mapper;

public class ContactsStaffTypeMapper : Profile
{
    public ContactsStaffTypeMapper()
    {
        CreateMap<ContactsStaffTypeDto, ContactsStaffType>().ReverseMap();
        CreateMap<ContactsStaffType, ContactsStaffTypeResponseDto>().ReverseMap();
    }
}
