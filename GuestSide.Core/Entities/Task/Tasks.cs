using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Enums;
using Core.Core.Entities.FeedBacks;
using Core.Core.Entities.Item;
using Core.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Task;

[Table("Tasks", Schema = "CSI")]
[Index(nameof(CartId))] 
[Index(nameof(LanguageCode))] 
[Index(nameof(IsCompleted))] 
[Index(nameof(DueDate))] 
public class Tasks : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(255)]
    public required string Description { get; set; }

    public DateTime? DueDate { get; set; } // Expected completion date

    public bool IsCompleted { get; set; } = false; // Indicates whether the task is completed

    public StatusEnum Status { get; set; } = StatusEnum.Pending; // More detailed status tracking

    public PriorityEnum Priority { get; set; } = PriorityEnum.Medium; // Task priority level

    [StringLength(10)]
    public string? LanguageCode { get; set; }

    [ForeignKey(nameof(Cart))]
    public long CartId { get; set; }

    public virtual Cart? Cart { get; set; } 

    [StringLength(255)]
    public string? Note { get; set; }

    public virtual List<Feedback>? Feedbacks { get; set; }

    public virtual List<TaskItem>? TaskItems { get; set; }

    public virtual TaskToStaff? TaskToStaff { get; set; }
}