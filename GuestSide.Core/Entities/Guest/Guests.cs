using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Item;
using Core.Core.Entities.Language;
using Core.Core.Entities.Notification;
using Core.Core.Entities.Restaurant;
using Core.Core.Entities.Room;

namespace Core.Core.Entities.Guest
{
    [Table("Guests", Schema = "CSI")]
    public class Guests : AbstractEntity//Status  use  this field for deactivate user, do not delete user info  for 3 year if  user re 
                                        //enter to hotel make it active and keep  he's  settings alive. ask him/het update profile preferences or just keep it up
    {
        [StringLength(100)]
        public required string FirstName { get; set; } = "Guest";//optional or will take default

        [StringLength(100)]
        public required string LastName { get; set; } = "Gustiashvili";//optional or will take default

        [StringLength(100)]
        [EmailAddress]
        public required string Email { get; set; } = "Guest@csi.com";//optional or will take default

        [StringLength(100)]
        public required string PhoneNumber { get; set; } = "555555555";//optional or will take default

        [StringLength(100)]
        public string? WhatWillRobotSay { get; set; }

        public byte[]? ProfilePicture { get; set; }//optional

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } = new DateTime(2002, 02, 20);//optional or will take default

        [StringLength(100)]
        public string? Country { get; set; } = "Georgia";//optional or will take default

        [StringLength(100)]
        public string? City { get; set; } = "Tbilisi";//optional or will take default

        [StringLength(100)]
        public string? Address { get; set; } = "Marjanishvilis Avenue N56";//optional or will take default

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Now;/// <summary>
                                                                 /// optional  or will get default value
                                                                 /// </summary>
        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        [StringLength(100)]
        public string? AdminNotes { get; set; }

        [ForeignKey("Status")]
        public long StatusId { get; set; } //update  this  record when user status change

        public bool IsFrequentGuest { get; set; } = false;//before retrive update this value from history  if the guest  was here before

        [NotMapped]
        public int TotalStayDuration => CheckOutDate.HasValue ? (CheckOutDate.Value - CheckInDate).Days : 0;

        [StringLength(100)]
        public string? EmergencyContactName { get; set; }//optional if clients want to in order to safety

        [StringLength(100)]
        public string? EmergencyContactPhone { get; set; }

        [StringLength(100)]
        public string? Preferences { get; set; } // habbbits  that  guest have

        [ForeignKey(nameof(Room))]
        public long RoomId { get; set; }
        [ForeignKey(nameof(LanguagePack))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? LanguagePack { get; set; }

        public virtual Rooms? Room { get; set; }

        public virtual Status? Status { get; set; }

        public GuestActiveLanguage ActiveLanguage { get; set; }

        public virtual IEnumerable<Cart>? Tasks { get; set; }

        public virtual IEnumerable<GuestNotification>? GuestNotifications { get; set; }

        public virtual IEnumerable<RestaurantCart> RestaurantCart { get; set; }

        public Guests(string pattern = "Hi {0} {1}, welcome to our hotel, we are glad to see you here")
        {
            WhatWillRobotSay = string.Format(pattern, FirstName, LastName);
        }
        public Guests()
        {

        }
    }
}
