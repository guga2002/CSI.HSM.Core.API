using Domain.Core.Entities.Task;

namespace Domain.Core.Sheared
{
    public class GroupTasksStatusByCard
    {
        public string Status { get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }
    }
}
