using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Request.Task;

public class TaskDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    public long LanguageId { get; set; }

    public long CategoryId { get; set; }

    public long CartId { get; set; }

    public long? OrderableItemId { get; set; }
}
