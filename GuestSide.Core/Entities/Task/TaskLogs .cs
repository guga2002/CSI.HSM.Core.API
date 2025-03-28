﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Task;

[Table("TaskLogs", Schema = "CSI")]
public class TaskLogs:AbstractEntity,IExistable<TaskLogs>
{
    [ForeignKey("Task")]
    public long TaskId { get; set; }
    public Tasks Task { get; set; } 
    public required string Action { get; set; }
    public required string PerformedBy { get; set; }
    public string? Notes { get; set; }
    public DateTime Timestamp { get; set; }

    public Expression<Func<TaskLogs, bool>> GetExistencePredicate()
    {
        return i=>i.TaskId == TaskId&&i.Action==i.Action;
    }
}
