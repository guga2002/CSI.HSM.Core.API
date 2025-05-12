using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Item;

[Table("ItemBehaviorTypes", Schema = "CSI")]
public class ItemBehaviorType : AbstractEntity
{
    public string? Name { get; set; }

    public string? Alias { get; set; }

    public string? Description {  get; set; }

    public virtual List<Items>? Items { get; set; }
}
