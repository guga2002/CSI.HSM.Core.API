using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Request.Staff
{
    public class StaffSentimentDto
    {
        public long StaffId { get; set; }

        public double SentimentScore { get; set; } 

        public double? SentimentConfidence { get; set; } 

        public string? SentimentLabel { get; set; }  

        [Column(TypeName = "nvarchar(max)")]
        public string? KeyPhrasesSerialized { get; set; }


        [StringLength(100)]
        public string? Emotion { get; set; }  // AI-predicted emotion (e.g., "Happy", "Frustrated", "Stressed")

        [StringLength(100)]
        public string? Source { get; set; }  

        public DateTime AnalysisDate { get; set; } = DateTime.UtcNow; 

        [StringLength(500)]
        public string? SuggestedAction { get; set; } 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
    }
}
