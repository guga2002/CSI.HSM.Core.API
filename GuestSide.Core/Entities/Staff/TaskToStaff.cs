﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Staff
{
    [Table("TaskToStaffs", Schema = "CSI")]
    [Index(nameof(StaffId))] 
    [Index(nameof(StatusId))] 
    [Index(nameof(TaskId))] 
    [Index(nameof(StartDate))] 
    [Index(nameof(EndDate))] 
    public class TaskToStaff : AbstractEntity
    {
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } = DateTime.UtcNow; 

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; } 

        [ForeignKey(nameof(Staff))]
        public long StaffId { get; set; }

        public virtual Staffs Staff { get; set; } 

        [ForeignKey(nameof(Status))]
        public long StatusId { get; set; }

        public virtual TasksStatus Status { get; set; } 

        [ForeignKey(nameof(Task))]
        public long TaskId { get; set; }

        public virtual Tasks Task { get; set; } 

        public bool IsCompleted { get; set; } = false; 

        [ForeignKey(nameof(AssignedByStaff))]
        public long? AssignedBy { get; set; } 

        public virtual Staffs? AssignedByStaff { get; set; } 


        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
    }

}
