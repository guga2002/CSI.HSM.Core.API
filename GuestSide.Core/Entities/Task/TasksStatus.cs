using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Core.Entities.Task
{
    [Table("TaskStatus")]
    public class TasksStatus:AbstractEntity
    {
        [Column("NameOfStatus")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<CartToStaff>CartToStaffs { get; set; }
    }
}
