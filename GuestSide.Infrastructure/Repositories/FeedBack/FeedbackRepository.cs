﻿using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.FeedBack;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuestSide.Infrastructure.Repositories.FeedBack
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<Feedback> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
