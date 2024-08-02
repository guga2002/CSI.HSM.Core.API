using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Staff
{
    [Table("Staffs")]
    public class Staff:AbstractEntity
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
    }
}
