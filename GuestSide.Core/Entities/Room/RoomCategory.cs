using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Language;

namespace Core.Core.Entities.Room;

[Table("RoomCategories", Schema = "CSI")]
public class RoomCategory : AbstractEntity
{
    [StringLength(100)]
    public required string Name { get; set; }
    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }

    public virtual LanguagePack? languagePack { get; set; }

    public virtual IEnumerable<Rooms>? Rooms { get; set; }

    public RoomCategory(string pattern = "Welcome to {0},there is more details for you:{1}")
    {
        WhatWillRobotSay = string.Format(pattern, Name, Description);
    }
    public RoomCategory()
    {

    }
}
