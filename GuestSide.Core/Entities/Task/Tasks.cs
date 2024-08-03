using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Item;

namespace GuestSide.Core.Entities.Task
{
    [Table("Tasks")]
    public class Tasks : AbstractEntity
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        //Date when the task was created
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        //date when the task is completed
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Status))]
        public long StatusId { get; set; }

        public TasksStatus Status { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }

        public TaskCategory Category { get; set; }

        public IEnumerable<Feedback> Feedbacks { get; set; }

        [ForeignKey(nameof(Cart))]
        public long CartId { get; set; }

        public Cart Cart { get; set; }

        [ForeignKey(nameof(Item))]
        public long ItemId { get; set; }

        public Items Item { get; set; }

    }
}
