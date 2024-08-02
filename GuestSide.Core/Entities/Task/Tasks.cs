using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Task
{
    [Table("Tasks")]
    public class Tasks:AbstractEntity
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        //Date when the task was created
        [DataType(DataType.Date)]
        public DateTime CreatedDate {  get; set; }

        //date when the task is completed
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Status))]
        public long StatusId {  get; set; }

        public TaskStatus Status { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }

        public TaskStatus Category { get; set; }
    }
}
