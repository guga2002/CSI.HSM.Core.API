using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;

namespace GuestSide.Application.DTOs.Request.Item
{
    public class CartDto
    {
        public long GuestId { get; set; }

        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}
