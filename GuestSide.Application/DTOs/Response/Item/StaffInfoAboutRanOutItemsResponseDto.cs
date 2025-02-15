using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core.Entities.Item;
using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Response.Item
{
    public class StaffInfoAboutRanOutItemsResponseDto
    {
        public long StaffId { get; set; }


        public List<long> ItemIds { get; set; }

        public DateTime RequestTime { get; set; }

        public RefillPriority Priority { get; set; }

        public bool Resolved { get; set; }

        public string? Notes { get; set; }

        public DateTime? HandledDate { get; set; }

        public bool IsUrgent { get; set; }
    }
}
