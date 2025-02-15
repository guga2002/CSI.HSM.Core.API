using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Language
{
    [Table("LanguagePacks", Schema = "CSI")]
    [Index(nameof(Code), IsUnique = true)] 
    [Index(nameof(Name), IsUnique = true)] 
    public class LanguagePack
    {
        [Key]
        public long Id { get; set; }

        [StringLength(10)] 
        public required string Code { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 

        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}