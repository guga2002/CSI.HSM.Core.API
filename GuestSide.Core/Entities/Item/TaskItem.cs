using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Task;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item
{
    [Table("TaskItems", Schema = "CSI")]
    [Index(nameof(TaskId))] // Optimized for task-item lookups
    [Index(nameof(ItemId))] // Optimized for item-task lookups
    [Index(nameof(IsCompleted))] // Helps in filtering completed vs. pending items
    public class TaskItem : AbstractEntity
    {
        [ForeignKey(nameof(Task))]
        public long TaskId { get; set; }

        public virtual Tasks Task { get; set; } 

        [ForeignKey(nameof(Item))]
        public long ItemId { get; set; }

        public virtual Items Item { get; set; } 

        public int Quantity { get; set; }

        public bool IsCompleted { get; set; } = false; 

        [ForeignKey(nameof(AssignedByStaff))]
        public long? AssignedByStaffId { get; set; } 

        public virtual Staffs? AssignedByStaff { get; set; } 

        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        [StringLength(300)]
        public string? Notes { get; set; } 
    }
}