using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Staff
{
    [Table("CartToStaffs", Schema = "CSI")]
    public class CartToStaff:AbstractEntity
    {
        //date when the task is assigned to staff
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        //date when the task is completed
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Staff))]
        public long StaffId {  get; set; }

        public Staffs Staff { get; set; }

        //carts status

        [ForeignKey(nameof(Status))]
        public long StatusId { get; set; }

        public TasksStatus Status { get; set; }

        [ForeignKey(nameof(Cart))]
        public long CartId { get; set; }

        public Cart Cart { get; set; }

    }
}
