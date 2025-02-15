
public class AdvertismentResponseDto
{
    public long Id { get; set; }

    public bool IsActive { get; set; } 
    public required string Title { get; set; }
    public string? Description { get; set; }

    public long AdvertisementTypeId { get; set; }


    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? LanguageCode { get; set; }

    public List<string>? PicturesUrl { get; set; }
}

