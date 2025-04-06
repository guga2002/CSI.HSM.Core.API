using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.FeedBacks;

[Table("Feedbacks", Schema = "CSI")]
[Index(nameof(CorrelationId))]
[Index(nameof(Rating))] 
[Index(nameof(LanguageCode))] 
[Index(nameof(TaskId))]
public class Feedback : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(100)]
    public required string Content { get; set; }

    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }

    public Guid CorrelationId { get; set; } = Guid.NewGuid();

    public int Rating { get; set; }

    [StringLength(10)] 
    public string? LanguageCode { get; set; }

    [ForeignKey(nameof(Task))]
    public long TaskId { get; set; }

    public virtual Tasks? Task { get; set; }

    public Feedback(string title, string content, string whatWillRobotSay = "Other clients give this feedback: {0}, {1}")
    {
        Title = title;
        Content = content;
        WhatWillRobotSay = string.Format(whatWillRobotSay, title, content);
    }

    public Feedback() { }
}