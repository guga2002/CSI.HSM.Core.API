using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Language;
using Core.Core.Entities.Task;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.FeedBacks;

[Table("Feedbacks", Schema = "CSI")]
public class Feedback : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }
    [StringLength(100)]
    public required string Content { get; set; }

    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }

    public Guid CorrelationId { get; set; }

    public int Rating { get; set; }

    public DateTime FeedbackDate { get; set; }

    [ForeignKey(nameof(LanguagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? LanguagePack { get; set; }

    [ForeignKey(nameof(Task))]
    public long TasksId { get; set; }
    public virtual Tasks? Task { get; set; }

    public Feedback(string whatwillRobotsay = "Other clients give this feedback{0},{1}")
    {
        WhatWillRobotSay = string.Format(whatwillRobotsay, Title, Content);
    }

    public Feedback()
    {

    }
}
