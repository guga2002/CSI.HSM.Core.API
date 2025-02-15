using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Staff
{
    [Table("StaffSentiments",Schema = "CSI")]
    public class StaffSentiment:AbstractEntity
    {
        [ForeignKey(nameof(StaffMember))]
        public long StaffId { get; set; }
        public double SentimentScore { get; set; }  // AI-generated score from -1 (negative) to +1 (positive)
        [StringLength(100)]
        public string? SentimentLabel { get; set; }  // "Positive", "Neutral", "Negative"
        public List<string>? KeyPhrases { get; set; }  // Extracted key phrases from analyzed text
        [StringLength(100)]
        public string? Emotion { get; set; }  // AI-predicted emotion (e.g., "Happy", "Frustrated", "Stressed")
        [StringLength(100)]       
        string? Source { get; set; }  // Where the sentiment data was gathered (e.g., "Task Feedback", "Customer Review")
        public DateTime AnalysisDate { get; set; }  // Timestamp when the sentiment was analyzed
        [StringLength(500)]
        public string? SuggestedAction { get; set; }  // Suggested action based on sentiment analysis
        public virtual Staffs? StaffMember { get; set; }
    }
}
