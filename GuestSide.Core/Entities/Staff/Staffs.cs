using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Notification;

namespace GuestSide.Core.Entities.Staff
{
    [Table("Staffs", Schema = "CSI")]
    public class Staffs:AbstractEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [ForeignKey(nameof(StaffCategory))]
        public long StaffCategoryId {  get; set; }

        public virtual StaffCategory? StaffCategory { get; set; }

        public virtual IEnumerable<StaffNotification>?StaffNotifications { get; set; }

        public virtual IEnumerable<TaskToStaff>? TaskToStaff { get; set; }
     

    }
}
