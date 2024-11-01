using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Feedbacks
{
    [Table("Feedbacks", Schema = "CSI")]
    public class Feedback:AbstractEntity
    {
        //Title of the feedback
        public required string Title { get; set; }

        //Detailed content of the feedback
        public required string Content { get; set; }

        public int Rating {  get; set; }

        public DateTime FeedbackDate {  get; set; }

        [ForeignKey(nameof(Task))]
        public long TasksId {  get; set; }
        public Tasks Task { get; set; }

    }
}
