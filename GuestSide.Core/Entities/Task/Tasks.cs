using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Task
{
    [Table("Tasks",Schema = "CSI")]
    public class Tasks : AbstractEntity
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? languagePack { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }

        public virtual TaskCategory? Category { get; set; }

        public virtual IEnumerable<Feedback>? Feedbacks { get; set; }

        [ForeignKey(nameof(Cart))]
        public long CartId { get; set; }

        public virtual Cart? Cart { get; set; }

        [ForeignKey(nameof(OrderableItem))]
        public long? OrderableItemId { get; set; }

        public virtual OrderableItem? OrderableItem { get; set; }
    }
}
