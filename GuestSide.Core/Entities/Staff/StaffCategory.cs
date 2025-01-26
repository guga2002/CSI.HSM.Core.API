using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.Item;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Staff;

[Table("StaffCategories", Schema = "CSI")]
public class StaffCategory:AbstractEntity
{
    public required string CategoryName { get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? languagePack { get; set; }
    public virtual IEnumerable<Staffs>?Staff { get; set; }

    public virtual IEnumerable<TaskToStaff>? TaskToStaff { get; set; }

    public virtual IEnumerable<ItemCategoryToStaffCategory> ItemCategoryToStaff { get; set;}
}
