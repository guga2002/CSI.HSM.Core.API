namespace Csi.RabbitMq.Models;

public class RabbitMqOptions
{
    public string HostName { get; set; } = "localhost";
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string VirtualHost { get; set; } = "/";
    public int Port { get; set; } = 5672;
    public bool UseTLS { get; set; } = false;
    public string? DeadLetterExchange { get; set; } = "dlx.exchange";
    public bool EnableDelayedExchange { get; set; } = false;
    public int MaxRetryAttempts { get; set; } = 3;
    public int RetryDelayMilliseconds { get; set; } = 10000;
}
