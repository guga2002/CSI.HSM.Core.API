﻿using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Staff
{
    public class CartToStaffDto
    {
        //date when the task is assigned to staff
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        //date when the task is completed
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public long StaffId { get; set; }

        //carts status
        public long StatusId { get; set; }

        public long CartId { get; set; }
    }
}
