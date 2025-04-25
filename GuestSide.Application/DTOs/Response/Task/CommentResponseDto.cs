using Domain.Core.Entities.Staff;
using Domain.Core.Entities.Task;

namespace Core.Application.DTOs.Response.Task;

public class CommentResponseDto : AbstractResponse
{
    public long StaffId { get; set; }

    public long TaskId { get; set; }

    public string? Text { get; set; }

    public virtual Staffs? Staff { get; set; }

    public virtual Tasks? Tasks { get; set; }
}
