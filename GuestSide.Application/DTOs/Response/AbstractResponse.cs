namespace Core.Application.DTOs.Response;

public abstract class AbstractResponse
{
    public long Id { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
