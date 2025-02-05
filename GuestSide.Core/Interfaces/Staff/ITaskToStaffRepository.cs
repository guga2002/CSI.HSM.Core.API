﻿using Core.Core.Sheared;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Core.Interfaces.Staff
{
    public interface ITaskToStaffRepository:IGenericRepository<TaskToStaff>
    {
        Task<TaskToStaff> GetByTaskId(long taskId);
        Task<IEnumerable<GroupTasksStatusByCard>> GetTasksStatusByCard(long cardId);
    }
}
