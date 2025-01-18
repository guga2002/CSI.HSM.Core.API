using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Feedbacks;

[Table("Feedbacks", Schema = "CSI")]
public class Feedback:AbstractEntity
{
    public required string Title { get; set; }
    public required string Content { get; set; }

    public string? WhatWillRobotSay { get; set; }

    public Guid CorrelationId { get; set; }

    public int Rating {  get; set; }

    public DateTime FeedbackDate {  get; set; }

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? languagePack { get; set; }

    [ForeignKey(nameof(Task))]
    public long TasksId {  get; set; }
    public virtual Tasks? Task { get; set; }

    public Feedback(string whatwillRobotsay="OTher clients give this feadback{0},{1}")
    {
        WhatWillRobotSay=string.Format(whatwillRobotsay, Title, Content);
    }

    public Feedback()
    {
        
    }
}
