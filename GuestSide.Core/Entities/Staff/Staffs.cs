using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Core.Entities.Staff
{
    [Table("Staffs")]
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

        public StaffCategory StaffCategory { get; set; }

        public IEnumerable<Cart> Tasks { get; set; }

        public IEnumerable<StaffNotification>StaffNotifications { get; set; }
     

    }
}
