using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Core.Entities.Staff;

namespace Core.Application.DTOs.Request.Staff
{
    public class StaffIncidentDto
    {
        public long ReportedByStaffId { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        public required string Severity { get; set; }

        public required string Status { get; set; }


        public string? ResolutionNotes { get; set; }

        public required string Location { get; set; } 

        public string? IncidentType { get; set; } 

        public DateTime UpdatedAt { get; set; } 

        public virtual Staffs? ReportedByStaff { get; set; }
    }
}
