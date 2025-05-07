using Domain.Core.Entities.AbstractEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Entities.Item
{
    [Table("ItemBehaviorTypes", Schema = "CSI")]
    public class ItemBehaviorType : AbstractEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Items> Items { get; set; }
    }
}
