using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Task
{
    [Table("TaskCategories",Schema = "CSI")]
    public class TaskCategory:AbstractEntity
    {
        public required string CategoryName { get; set; }

        public string? Description {  get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }
    }
}
