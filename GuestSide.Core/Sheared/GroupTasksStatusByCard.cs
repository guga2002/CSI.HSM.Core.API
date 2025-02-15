using Core.Core.Entities.Task;

namespace Core.Core.Sheared
{
    public class GroupTasksStatusByCard
    {
        public string Status { get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }
    }
}
