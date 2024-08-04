﻿using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.Notification
{
    public class GuestNotificationRepository : GenericRepository<GuestNotification>, IGuestNotificationRepository
    {
        public GuestNotificationRepository(DbContext context) : base(context)
        {
        }
    }
}
