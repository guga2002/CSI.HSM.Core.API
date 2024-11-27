using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;

namespace GuestSide.Application.DTOs.Response.Item
{
    public class CartResponseDto
    {
        public long Id { get; set; }

        public long GuestId { get; set; }

        public IEnumerable<TaskResponseDto> Tasks { get; set; }
    }
}
