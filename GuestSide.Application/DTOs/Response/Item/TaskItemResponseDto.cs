using Core.Core.Entities.Item;
using Core.Core.Entities.Staff;
using Core.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Item;

public class TaskItemResponseDto
{
    public long Id { get; set; }

    public long TaskId { get; set; }

    public long ItemId { get; set; }

    public int Quantity { get; set; }

    public bool IsCompleted { get; set; } = false;

    public long? AssignedByStaffId { get; set; }

    public DateTime AssignedDate { get; set; } 

    public string? Notes { get; set; }
}
