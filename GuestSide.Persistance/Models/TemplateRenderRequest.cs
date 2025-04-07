namespace Core.Persistance.Models;

public class TemplateRenderRequest
{
    public string TemplateKey { get; set; }
    public string? Language { get; set; }
    public Dictionary<string, string> Data { get; set; } = new();
}
