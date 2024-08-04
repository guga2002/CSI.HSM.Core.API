using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Advertisment
{
    public class AdvertismentDto
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public long AdvertisementTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public required string MediaUrl { get; set; }
    }
}
