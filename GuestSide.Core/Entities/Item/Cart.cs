using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item
{
    [Table("Carts", Schema = "CSI")]
    [Index(nameof(GuestId))] // Optimized for guest-cart joins
    [Index(nameof(LanguageCode))] // Improves filtering by language
    [Index(nameof(IsComplete))] // Optimized for active/inactive cart filtering
    public class Cart : AbstractEntity
    {
        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }

        [StringLength(100)]
        public string? WhatWillRobotSay { get; set; } = "Hi Guest, you initialized your cart. Happy shopping!";

        public virtual Guests? Guest { get; set; } // Virtual for lazy loading

        public virtual List<Tasks> Tasks { get; set; } = new(); // Proper ORM handling

        [StringLength(10)] // Optimized for storing language codes
        public string? LanguageCode { get; set; }

        public bool IsComplete { get; set; }

        public Cart() { }

        public Cart(string pattern = "Hi {0}, you initialized your cart. Happy shopping!")
        {
            WhatWillRobotSay = pattern;
        }
    }
}