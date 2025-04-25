using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Contacts;

[Table("StaffTypes", Schema = "CSI")]

public class ContactsStaffType : AbstractEntity
{
    public required string StaffType { get; set; }

    public virtual List<Contact>? Contacts { get; set; }
}
