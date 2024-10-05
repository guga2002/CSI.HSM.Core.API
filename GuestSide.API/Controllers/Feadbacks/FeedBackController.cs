using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Feedbacks;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Feadbacks
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : CSIControllerBase<FeedbackDto, long, Feedback>
    {
        public FeedBackController(IService<FeedbackDto, long, Feedback> serviceProvider) : base(serviceProvider)
        {
        }
    }
}
