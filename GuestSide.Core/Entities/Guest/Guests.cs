using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Core.Entities.Guest
{
    [Table("Guests", Schema = "CSI")]
    public class Guests : AbstractEntity//Status  use  this field for deactivate user, do not delete user info  for 3 year if  user re 
        //enter to hotel make it active and keep  he's  settings alive. ask him/het update profile preferences or just keep it up
    {
        public required string FirstName { get; set; }= "Guest";//optional or will take default

        public required string LastName { get; set; }="Gustiashvili";//optional or will take default

        public required string Email { get; set; }="Guest@csi.com";//optional or will take default

        public required string PhoneNumber { get; set; }= "555555555";//optional or will take default

        public string? WhatWillRobotSay { get; set; }

        public byte[]? ProfilePicture { get; set; }//optional

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } = new DateTime(2002, 02, 20);//optional or will take default

        public string? Country { get; set; } = "Georgia";//optional or will take default

        public string? City { get; set; }= "Tbilisi";//optional or will take default

        public string? Address { get; set; }="Marjanishvilis Avenue N56";//optional or will take default

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Now;/// <summary>
        /// optional  or will get default value
        /// </summary>

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }

        public string? AdminNotes { get; set; }

        [ForeignKey("Status")]
        public long StatusId { get; set; } //update  this  record when user status change

        public bool IsFrequentGuest { get; set; } = false;//before retrive update this value from history  if the guest  was here before

        [NotMapped]
        public int TotalStayDuration =>(CheckOutDate.HasValue ? (CheckOutDate.Value - CheckInDate).Days : 0);

        public string? EmergencyContactName { get; set; }//optional if clients want to in order to safety

        public string? EmergencyContactPhone { get; set; }

        public string? Preferences { get; set; } // habbbits  that  guest have

        [ForeignKey(nameof(Room))]
        public long RoomId{ get; set; }
        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }
        public virtual LanguagePack?languagePack { get; set; }

        public virtual Rooms? Room{ get; set; }

        public virtual Status? Status { get; set; }

        public virtual  IEnumerable<Cart>?Tasks { get; set; }

        public virtual IEnumerable<GuestNotification>? GuestNotifications { get; set; }

        public Guests(string pattern= "Hi {0} {1}, welcome to our hotel, we are glad to see you here")
        {
            WhatWillRobotSay= string.Format(pattern, FirstName, LastName);
        }
        public Guests()
        {
            
        }
    }
}
