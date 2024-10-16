using GuestSide.Application.DTOs.Task;

namespace GuestSide.Application.DTOs.Item
{
    public class CartDto
    {
        public long GuestId { get; set; }

        public  IEnumerable<TaskDto> Tasks { get; set; }
    }
}
