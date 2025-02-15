using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Item;
using Core.Core.Entities.Language;

namespace Core.Core.Entities.Staff;

[Table("StaffCategories", Schema = "CSI")]
public class StaffCategory : AbstractEntity
{
    [StringLength(100)]
    public required string CategoryName { get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? languagePack { get; set; }
    public virtual IEnumerable<Staffs>? Staff { get; set; }

    public virtual IEnumerable<TaskToStaff>? TaskToStaff { get; set; }

    public virtual IEnumerable<ItemCategoryToStaffCategory> ItemCategoryToStaff { get; set; }
}
