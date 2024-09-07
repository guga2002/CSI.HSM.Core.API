using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Task
{
    public class TaskDto
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }

        public TaskCategory Category { get; set; }

        public long CartId { get; set; }

        public long ItemId { get; set; }
    }
}
