using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Models;

public class Template
{
    public string Id { get; set; }
    public string Key { get; set; }
    public string Type { get; set; }
    public string Language { get; set; }
    public string Filename { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; } = true;
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
