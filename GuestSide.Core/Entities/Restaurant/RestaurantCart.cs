using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Restaurant
{
    public class RestaurantCart:AbstractEntity
    {
        [ForeignKey(nameof(guest))]
        public long GuestId { get; set; }

        public string? WhatWillRobotSay { get; set; }

        public virtual Guests? guest { get; set; }

        [ForeignKey(nameof(RestaunrantItem))]
        public long RestaunrantItemId { get; set; }

        public virtual IEnumerable<RestaunrantItem>? RestaunrantItem { get; set; }
    }
}
