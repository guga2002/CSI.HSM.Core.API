﻿using GuestSide.Core.Data;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.Task;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Task
{
    public class TaskCategoryRepository : GenericRepository<TaskCategory>, ITaskCategoryRepository
    {
        public TaskCategoryRepository(GuestSideDb context) : base(context)
        {
        }
    }
}
