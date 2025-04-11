using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Staff;

[Table("StaffSentiments", Schema = "CSI")]
[Index(nameof(StaffId))]
[Index(nameof(SentimentScore))]
[Index(nameof(SentimentLabel))]
[Index(nameof(Emotion))]
[Index(nameof(AnalysisDate))]
public class StaffSentiment : AbstractEntity
{
    [ForeignKey(nameof(StaffMember))]
    public long StaffId { get; set; }

    public double SentimentScore { get; set; }  // AI-generated score from -1 (negative) to +1 (positive)

    public double? SentimentConfidence { get; set; } // Confidence level of AI sentiment prediction (0-1)

    [StringLength(100)]
    public string? SentimentLabel { get; set; }  // "Positive", "Neutral", "Negative"

    [Column(TypeName = "nvarchar(max)")]
    public string? KeyPhrasesSerialized { get; set; }

    [NotMapped]
    public List<string>? KeyPhrases
    {
        get => KeyPhrasesSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(KeyPhrasesSerialized);
        set => KeyPhrasesSerialized = value == null ? null : JsonSerializer.Serialize(value);
    }

    [StringLength(100)]
    public string? Emotion { get; set; }  // AI-predicted emotion (e.g., "Happy", "Frustrated", "Stressed")

    [StringLength(100)]
    public string? Source { get; set; }  // Where the sentiment data was gathered (e.g., "Task Feedback", "Customer Review")

    public DateTime AnalysisDate { get; set; } = DateTime.UtcNow; // Timestamp when sentiment was analyzed

    [StringLength(500)]
    public string? SuggestedAction { get; set; }  // Suggested action based on sentiment analysis

    public virtual Staffs? StaffMember { get; set; } // Virtual for lazy loading
}
