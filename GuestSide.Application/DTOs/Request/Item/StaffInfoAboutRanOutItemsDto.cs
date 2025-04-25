using Core.Application.DTOs.Response;
using Domain.Core.Entities.Enums;

namespace Core.Application.DTOs.Request.Item;

public class StaffInfoAboutRanOutItemsDto : AbstractResponse
{
    public long StaffId { get; set; }

    public List<long> ItemIds { get; set; }

    public DateTime RequestTime { get; set; }

    public PriorityEnum Priority { get; set; }

    public bool Resolved { get; set; }

    public string? Notes { get; set; }

    public DateTime? HandledDate { get; set; }
}
