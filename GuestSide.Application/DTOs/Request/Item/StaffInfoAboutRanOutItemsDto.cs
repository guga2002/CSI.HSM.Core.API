using Core.Core.Entities.Item;

namespace Core.Application.DTOs.Request.Item
{
    public class StaffInfoAboutRanOutItemsDto
    {
        public long StaffId { get; set; }

        public List<long> ItemIds {get ; set ; }

        public DateTime RequestTime { get; set; }

        public RefillPriority Priority { get; set; }

        public bool Resolved { get; set; }

        public string? Notes { get; set; }

        public DateTime? HandledDate { get; set; }
    }
}
