﻿using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.FeedBack;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.FeedBack
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DbContext context) : base(context)
        {
        }
    }
}
