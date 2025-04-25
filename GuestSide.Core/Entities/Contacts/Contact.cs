using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Contacts;

[Table("Contacts", Schema = "CSI")]
public class Contact : AbstractEntity
{
    [Required, StringLength(100)]
    public string Name { get; set; } = default!;

    [Required, StringLength(150)]
    public string Mail { get; set; } = default!;

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [ForeignKey(nameof(StaffType))]
    public long StaffTypeId { get; set; }

    public virtual ContactsStaffType? StaffType { get; set; }
}
