using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Staff;

public class StaffSentimentResponseDto : AbstractResponse
{
    public long StaffId { get; set; }

    public double SentimentScore { get; set; }

    public double? SentimentConfidence { get; set; }

    public string? SentimentLabel { get; set; }

    public List<string>? KeyPhrases { get; set; }

    [StringLength(100)]
    public string? Emotion { get; set; }

    [StringLength(100)]
    public string? Source { get; set; }

    public DateTime AnalysisDate { get; set; }

    [StringLength(500)]
    public string? SuggestedAction { get; set; }

    public virtual StaffResponseDto? StaffMember { get; set; }
}
