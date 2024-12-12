using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Notification
{
    [Table("Notifications", Schema = "CSI")]
    public class Notifications:AbstractEntity
    {
        public required string Title { get; set; }

        public required string Message { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool IsRead { get; set; } = false;//will change after sent//do not give a fuck,  reciever  get it or not

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? languagePack { get; set; }

        public virtual IEnumerable<StaffNotification>? StaffNotifications { get; set; }

        public virtual IEnumerable<GuestNotification>? GuestNotifications { get; set; }

        public Notifications(string pattern="You got new notification:{0},{1}}")
        {
            WhatWillRobotSay= string.Format(pattern, Title, Message);
        }
    }
}
