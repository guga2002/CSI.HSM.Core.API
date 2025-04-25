namespace Csi.RabbitMq.Models;

public class RabbitMqEnvelope<T>
{
    public string Type { get; set; } = typeof(T).Name;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public T? Payload { get; set; }
}
