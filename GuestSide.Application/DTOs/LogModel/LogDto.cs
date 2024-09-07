namespace GuestSide.Application.DTOs.Log
{
    public class LogDto
    {
        public required string LogLevel { get; set; }
        public required string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public required string Exception { get; set; }
        public string? Source { get; set; }
    }
}
