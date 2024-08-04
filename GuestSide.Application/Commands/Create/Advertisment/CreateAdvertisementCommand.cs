namespace GuestSide.Application.Commands.Create.Advertisment
{
    public class CreateAdvertisementCommand
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public long AdvertisementTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MediaUrl { get; set; }
    }
}
