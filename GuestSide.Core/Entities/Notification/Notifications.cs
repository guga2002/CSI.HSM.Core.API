using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Notification;

[Table("Notifications", Schema = "CSI")]
public class Notifications : AbstractEntity
{
    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(100)]
    public required string Message { get; set; }

    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }

    public DateTime NotificationDate { get; set; }

    public bool IsSent { get; set; } = false;

    [ForeignKey(nameof(languagePack))]
    public long LanguageId { get; set; }
    public virtual LanguagePack? languagePack { get; set; }

    public virtual IEnumerable<StaffNotification>? StaffNotifications { get; set; }

    public virtual IEnumerable<GuestNotification>? GuestNotifications { get; set; }

    public Notifications(string pattern = "You got new notification:{0},{1}}")
    {
        WhatWillRobotSay = string.Format(pattern, Title, Message);
    }
    public Notifications()
    {

    }
}
