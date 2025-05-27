using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Notification;

[Table("FailedNotifications", Schema = "CSI")]
public class FailedNotification : AbstractEntity
{
    public string? Data { get; set; } //Json property sadac sheinaxeba data ar gagzavnilebis

    public int Status { get; set; } // 0 xeli ar mogvikidia, 5 gatarebulia, 8 dafeilebuli

    public int Count { get; set; } //imis dasadgenad ramdenjer vcadet tavidan gagzavna
}

