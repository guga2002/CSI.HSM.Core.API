using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Room
{
    [Table("RoomCategories", Schema = "CSI")]
    public class RoomCategory:AbstractEntity
    {
        public required string Name { get; set; }
        public string? WhatWillRobotSay { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }

        public virtual LanguagePack? languagePack { get; set; }

        public virtual IEnumerable<Rooms>?Rooms { get; set; }

        public RoomCategory(string Pattern="Welcome to {0},there is more details for you:{1}")
        {
            WhatWillRobotSay = String.Format(Pattern, Name, Description);
        }
        public RoomCategory()
        {
            
        }
    }
}
