using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;

namespace Core.Core.Entities.Item;

[Table("StaffReserveItems", Schema = "CSI")]
public class StaffReserveItem : AbstractEntity //job will  release items automatic if staff not do
{
    [ForeignKey(nameof(StaffMember))] 
    public long StaffId { get; set; }
    [ForeignKey(nameof(Item))] 
    public long ItemId { get; set; }
    public int Quantity { get; set; }
    public bool FinalUsed { get; set; } = false;
    public DateTime ReservationDate { get; set; }
    public DateTime ReservedTill { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    [StringLength(300)]
    public string? Notes { get; set; }
    public virtual Staffs? StaffMember { get; set; }
    public virtual Items? Item { get; set; }
}
