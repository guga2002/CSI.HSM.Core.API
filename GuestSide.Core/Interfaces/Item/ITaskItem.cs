﻿using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Item;

public interface ITaskItem:IGenericRepository<TaskItem>
{
    Task<IEnumerable<TaskItem>> GetTaskItemsByCartId(long CartId);
}
