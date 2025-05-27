using Common.Data.Entities.Contacts;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Contacts;

public interface IContactsStaffTypeService : IService<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>,
    IAdditionalFeatures<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>
{
}