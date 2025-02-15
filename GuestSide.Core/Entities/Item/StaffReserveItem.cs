using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Item
{
    [Table("StaffReserveItems", Schema = "CSI")]
    [Index(nameof(StaffId))] 
    [Index(nameof(ItemId))] 
    [Index(nameof(FinalUsed))] 
    [Index(nameof(ReservedTill))] 
    [Index(nameof(IsExpired))] 
    public class StaffReserveItem : AbstractEntity
    {
        [ForeignKey(nameof(StaffMember))]
        public long StaffId { get; set; }

        public virtual Staffs? StaffMember { get; set; } 

        [ForeignKey(nameof(Item))]
        public long ItemId { get; set; }

        public virtual Items? Item { get; set; } 

        public int Quantity { get; set; }

        public bool FinalUsed { get; set; } = false; // Indicates if the reservation was used

        public DateTime ReservationDate { get; set; } = DateTime.UtcNow; // Default reservation timestamp

        public DateTime ReservedTill { get; set; } // Specifies expiration date of reservation

        public DateTime? RequiredDate { get; set; } // When the item is actually needed

        public DateTime? ReturnDate { get; set; } // When the item is returned

        public bool IsExpired => DateTime.UtcNow > ReservedTill && !FinalUsed; // Automatically calculated field

        public bool ReleasedBySystem { get; set; } = false; 

        public DateTime? HandledDate { get; set; } // Stores when the reservation was finalized

        [StringLength(300)]
        public string? Notes { get; set; }
    }
}
