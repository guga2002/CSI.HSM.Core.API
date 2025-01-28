using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Response.Task;

public class TaskResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }

    public long LanguageId { get; set; }

    public long CategoryId { get; set; }

    public long CartId { get; set; }

    public long? OrderableItemId { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }
}