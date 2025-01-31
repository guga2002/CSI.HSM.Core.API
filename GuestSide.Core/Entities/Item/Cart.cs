using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item;

[Table("Carts", Schema = "CSI")]
[Index(nameof(LanguageId))]
public class Cart : AbstractEntity
{
    [ForeignKey(nameof(guest))]
    public long GuestId { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public virtual Guests? guest { get; set; }

    public virtual IEnumerable<Tasks> Tasks { get; set; }

    [ForeignKey(nameof(language))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? language { get; set; }

    public decimal SubTotal=>Tasks?.Sum(x=>x.Total)??0;

    public Cart(string PatternWhatWillwobotSay = "HI {0}, you inicialize card,  happy  shopping")
    {
        WhatWillRobotSay = string.Format(PatternWhatWillwobotSay, guest?.FirstName+" "+guest?.LastName);
    }
    public Cart()
    {
        
    }
}
