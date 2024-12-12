using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Hotel;
using GuestSide.Core.Entities.Language;

namespace GuestSide.Core.Entities.Room
{
    [Table("Rooms", Schema = "CSI")]
    public class Rooms:AbstractEntity
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public string? WhatWillRobotSay { get; set; }
        public bool IsAvailable { get; set; }=true;
        public List<byte[]>? Pictures { get; set; }//optional if staff upload pictures it  will be  showed  there

        [ForeignKey(nameof(RoomCategory))]
        public long RoomCategoryId { get; set; }

        [ForeignKey(nameof(Hotel))]
        public long  HotelId { get; set; }

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }
        public virtual LanguagePack? languagePack { get; set; }

        public virtual Hotel.Hotel? Hotel { get; set; }
        public virtual RoomCategory? RoomCategory { get; set; }

        public virtual IEnumerable<Guests>?Guests { get; set; }

        public virtual QRCode? QRCode { get; set; }

        public Rooms(string pattern="You are in {0} floor, your room number is{1}")
        {
            WhatWillRobotSay = string.Format(pattern, Floor, RoomNumber);
        }

        public Rooms()
        {
            
        }
    }
}
